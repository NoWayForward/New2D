using System.Numerics;
using New2D.Helpers;
using Raylib_cs;

namespace New2D.GameObjects.Character.Player;

public class Player : IGameObject, IControllable, ICollidable, IKillable, IPlayer
{
    public bool IsVisible { get; } = true;
    public Vector2 Coordinates { get; internal set; }
    public Vector2 PreviousCoordinates { get; internal set; }
    public Rectangle Bounds { get; set; }
    
    public bool UpdatedX { get; private set; }
    public bool UpdatedY { get; private set; }
    
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
            // Raylib.DrawRectangleRec(Bounds, Color.Green);
            Raylib.DrawTexture(texture, (int)Coordinates.X, (int)Coordinates.Y, Color.White);
        }
    }

    public float Speed { get; } = (float)1.4;

    public void ControlX()
    {
        PreviousCoordinates = this.Coordinates;
        
        bool left = Raylib.IsKeyDown(KeyboardKey.A);
        bool right = Raylib.IsKeyDown(KeyboardKey.D);
       // bool jump = Raylib.IsKeyDown(KeyboardKey.Space);
       
       if (right) this.Coordinates = Coordinates with { X = Coordinates.X + Speed };
       if (left) this.Coordinates = Coordinates with { X = Coordinates.X - Speed };

       this.UpdatedX = PreviousCoordinates.X != this.Coordinates.X; 
       
       Bounds = new Rectangle((int)Coordinates.X, (int)Coordinates.Y, texture.Width, texture.Height);
    }
    public void ControlY()
    {
        PreviousCoordinates = this.Coordinates;
        
        bool up = Raylib.IsKeyDown(KeyboardKey.W);
        bool down = Raylib.IsKeyDown(KeyboardKey.S);
        // bool jump = Raylib.IsKeyDown(KeyboardKey.Space);
        
        if (up) this.Coordinates = Coordinates with { Y = Coordinates.Y - Speed };
        if (down) this.Coordinates = Coordinates with { Y = Coordinates.Y + Speed };
       
        this.UpdatedY = PreviousCoordinates.Y != this.Coordinates.Y; 
        
        Bounds = new Rectangle((int)Coordinates.X, (int)Coordinates.Y, texture.Width, texture.Height);
    }


    public void Revert()
    {
        this.Coordinates = PreviousCoordinates;
        Bounds = new Rectangle((int)PreviousCoordinates.X, (int)PreviousCoordinates.Y, texture.Width, texture.Height);
    }

    public int Health { get; set; }
    public void Hurt(int damage)
    {
        Console.WriteLine("Hurt");
        Health = Health - damage;
        if (Health <= 0)
        {
            Console.WriteLine("Game Over");
            Common.gameStatus = GameStatus.gameOver;
        }
    }

    public void Heal(int heal)
    {
        Health += heal;
    }
}