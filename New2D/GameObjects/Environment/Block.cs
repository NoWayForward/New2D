using System.Numerics;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.GameObjects.Enviornment;

public class Block : ICollidable, IRenderable
{
    public Rectangle Bounds { get; set; }

    public Block(Rectangle bounds)
    {
        this.Bounds = bounds;
    }
    public void Draw()
    {
        Raylib.DrawRectangleRec(Bounds, Color.White);
    }

    public bool IsVisible { get; }
    public Vector2 Coordinates { get; }
}