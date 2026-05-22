using System.Numerics;
using New2D.GameObjects;
using New2D.GameObjects.Character;
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
        if (obj is IRenderable)
            Renderables.Add((IRenderable)obj);
        if (obj is IClickable)
            Clickables.Add((IClickable)obj);
        if (obj is IControllable)
            Controllables.Add((IControllable)obj);
        if (obj is ICollidable)
            Collidables.Add((ICollidable)obj);
            
    }
    protected void UnregisterObjects(Object obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));
        if (obj is IRenderable)
            Renderables.Remove((IRenderable)obj);
        if (obj is IClickable)
            Clickables.Remove((IClickable)obj);
        if (obj is IControllable)
            Controllables.Remove((IControllable)obj);
        if (obj is ICollidable)
            Collidables.Remove((ICollidable)obj);
    }
    public void Handle()
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        foreach (IRenderable renderable in Renderables)
            renderable.Draw();
        
        foreach(IControllable controllable in Controllables)
        {
            controllable.Control();
            foreach (ICollidable collidable in Collidables)
            {
                if (CheckCollision(controllable, collidable))
                {
                    controllable.Revert();
                }
                else continue;
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