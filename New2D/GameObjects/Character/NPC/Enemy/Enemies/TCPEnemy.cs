using System.Numerics;
using New2D.GameObjects.Character.NPC.Enemy.Enemies;
using New2D.Helpers;
using New2D.Renderer;
using New2D.Scene;
using Raylib_cs;

namespace New2D.GameObjects.Character.NPC.Enemy;

public class TcpEnemy(IWorldContext context, Vector2 coordinates, TcpServer server)
    : IRenderable, ICollidable, IControllable, INonPlayerCharacter, IEnemy
{
    public Rectangle Bounds { get; set; }
    private IWorldContext WorldContext { get; } = context;
    public Vector2 Coordinates { get; protected set; } = coordinates;
    protected Vector2 PreviousCoordinates { get; set; }
    private float speed = 2;
    private Texture2D texture = Raylib.LoadTexture(Common.ProjectRoot + "Textures/Enemy/Ball.png");
    

    public void ControlX()
    {
        this.PreviousCoordinates = this.Coordinates;
        
    }

    public void ControlY() { 
        this.PreviousCoordinates = this.Coordinates;
        
    }

    public bool UpdatedX { get; private set; }
    public bool UpdatedY { get; private set; }
    public void Revert()
    {
        Coordinates = PreviousCoordinates;
    }
    public void Draw()
    {
        server.Actions.Pop();
        Raylib.DrawTexture(texture, (int)Coordinates.X, (int)Coordinates.Y, Color.White);
    }

    public bool IsVisible { get; }
}