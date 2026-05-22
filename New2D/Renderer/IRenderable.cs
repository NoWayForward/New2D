using System.Numerics;
using Raylib_cs;

namespace New2D.Renderer;

public interface IRenderable
{
    public void Draw();
    public bool IsVisible { get; }
    public Vector2 Coordinates { get; }
}