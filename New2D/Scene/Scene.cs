using System.Numerics;
using New2D.GameObjects;
using New2D.GameObjects.Character;
using New2D.GameObjects.Character.NPC.Enemy.Enemies;
using New2D.GameObjects.Character.Player;
using New2D.Helpers;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.Scene;

public abstract class Scene
{
    protected List<IRenderable> Renderables { get; } = new();
    protected List<IClickable> Clickables { get; } = new();
    protected List<IControllable> Controllables { get; } = new();
    protected List<ICollidable> Collidables { get; } = new();
    public void Unload(Renderer.Renderer renderer)
    {
        Renderables.Clear();
        Clickables.Clear();
        Controllables.Clear();
        Collidables.Clear();
    }
    protected void RegisterObjects(Object obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));
        if (obj is IRenderable renderable)
            Renderables.Add(renderable);
        if (obj is IClickable clickable)
            Clickables.Add(clickable);
        if (obj is IControllable controllable)
            Controllables.Add(controllable);
        if (obj is ICollidable collidable)
            Collidables.Add(collidable);
            
    }
    protected void UnregisterObjects(Object obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));
        if (obj is IRenderable renderable)
            Renderables.Remove(renderable);
        if (obj is IClickable clickable)
            Clickables.Remove(clickable);
        if (obj is IControllable controllable)
            Controllables.Remove(controllable);
        if (obj is ICollidable collidable)
            Collidables.Remove(collidable);
    }
    public void Handle()
    {
        if (Common.gameStatus == GameStatus.gameOver)
        {
            Common.gameStatus = GameStatus.gameRunning;
            GameState.GameState.ChangeScene(new MenuScene());
        }
        Vector2 mousePos = Raylib.GetMousePosition();
        if (!Common.IsHeadless)
            foreach (IRenderable renderable in Renderables)
                renderable.Draw();
        
        foreach(IControllable controllable in Controllables)
        {
            controllable.ControlX();
            if (controllable.UpdatedX)
            {
                foreach (ICollidable collidable in Collidables)
                {
                    if (CheckCollision(controllable, collidable))
                    {
                        if (controllable is IEnemy && collidable is IPlayer and IKillable player)
                        {
                            player.Hurt(Int32.MaxValue);
                        }
                        controllable.Revert();
                    }
                }
            }
            controllable.ControlY();
            if (controllable.UpdatedY)
            {
                foreach (ICollidable collidable in Collidables)
                {
                    if (CheckCollision(controllable, collidable))
                    {
                        if (controllable is IEnemy && collidable is IPlayer and IKillable player)
                        {
                            player.Hurt(Int32.MaxValue);
                        }
                        controllable.Revert();
                    }
                }
            }
        }
        
        foreach (IClickable clickable in Clickables.ToList())
        {
            clickable.IsHovered = Common.IsHovered(clickable.Bounds);
            ;
            if (Raylib.IsMouseButtonDown(MouseButton.Left) && Common.IsHovered(clickable.Bounds))
            {
                clickable.OnClick();
            }
        }
    }

    private static bool CheckCollision(IControllable controllable, ICollidable collidable)
    {
        if (controllable is not ICollidable c) return false;
        if (ReferenceEquals(c, collidable)) return false; // Check if object is self, return false
        if (Raylib.CheckCollisionRecs(c.Bounds, collidable.Bounds)) Console.WriteLine(DateTime.Now + controllable.ToString() + " is colliding with " + collidable.ToString() + ".");
        return Raylib.CheckCollisionRecs(c.Bounds, collidable.Bounds);
    }
}