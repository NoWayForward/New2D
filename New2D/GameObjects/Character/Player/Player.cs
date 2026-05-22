using System.Numerics;
using New2D.Helpers;
using Raylib_cs;

namespace New2D.GameObjects.Character.Player;

public class Player : IGameObject, IControllable, ICollidable
{
    public bool IsVisible { get; } = true;
    public Vector2 Coordinates { get; internal set; }
    public Vector2 PreviousCoordinates { get; internal set; }
    public Rectangle Bounds { get; set; }

    public Player(Vector2 coordinates)
    {
        this.Coordinates = coordinates;
        texture = Raylib.LoadTexture(Common.ProjectRoot + "Textures/Player/Player.png");
    }
    public Texture2D texture { get; private set; } 
    public void Draw()
    {
        if (this.IsVisible)
        {
            Raylib.DrawRectangleRec(Bounds, Color.Green);
            Raylib.DrawTexture(texture, (int)Coordinates.X, (int)Coordinates.Y, Color.White);
        }
    }

    public float Speed { get; } = (float)1.4;

    public bool Control()
    {
        PreviousCoordinates = this.Coordinates;
        
        bool up = Raylib.IsKeyDown(KeyboardKey.W);
        bool down = Raylib.IsKeyDown(KeyboardKey.S);
        bool left = Raylib.IsKeyDown(KeyboardKey.A);
        bool right = Raylib.IsKeyDown(KeyboardKey.D);
       // bool jump = Raylib.IsKeyDown(KeyboardKey.Space);
       
       if (right) this.Coordinates = Coordinates with { X = Coordinates.X + Speed };
       if (left) this.Coordinates = Coordinates with { X = Coordinates.X - Speed };
       if (up) this.Coordinates = Coordinates with { Y = Coordinates.Y - Speed };
       if (down) this.Coordinates = Coordinates with { Y = Coordinates.Y + Speed };
       
       Bounds = new Rectangle((int)Coordinates.X, (int)Coordinates.Y, texture.Width, texture.Height);
        return up || down || left || right;
    }

    public void Revert()
    {
        this.Coordinates = PreviousCoordinates;
        Bounds = new Rectangle((int)PreviousCoordinates.X, (int)PreviousCoordinates.Y, texture.Width, texture.Height);
    }
}