using System.Numerics;
using New2D.GameObjects.Character.NPC.Enemy.Enemies;
using New2D.Helpers;
using New2D.Renderer;
using New2D.Scene;
using Raylib_cs;

namespace New2D.GameObjects.Character.NPC.Enemy;

public class Enemy(IWorldContext context, Vector2 coordinates)
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
        float dif = WorldContext.PlayerPosition.X - Coordinates.X; // get difference to player x position
        if (dif > 0) this.Coordinates = Coordinates with {X = Coordinates.X + speed};
        else this.Coordinates = Coordinates with {X = Coordinates.X - speed};
        Bounds = new Rectangle((int)Coordinates.X, (int)Coordinates.Y, texture.Width, texture.Height);
        UpdatedX = this.PreviousCoordinates == Coordinates;
    }

    public void ControlY() { this.PreviousCoordinates = this.Coordinates;
        float dif = WorldContext.PlayerPosition.Y - Coordinates.Y; // get difference to player x position
        if (dif > 0) this.Coordinates = Coordinates with {Y = Coordinates.Y + speed};
        else this.Coordinates = Coordinates with {Y = Coordinates.Y - speed};
        Bounds = new Rectangle((int)Coordinates.X, (int)Coordinates.Y, texture.Width, texture.Height);
        UpdatedY = this.PreviousCoordinates == Coordinates;
    }

    public bool UpdatedX { get; private set; }
    public bool UpdatedY { get; private set; }
    public void Revert()
    {
        Coordinates = PreviousCoordinates;
    }
    public void Draw()
    {
        Raylib.DrawTexture(texture, (int)Coordinates.X, (int)Coordinates.Y, Color.White);
    }

    public bool IsVisible { get; }
}