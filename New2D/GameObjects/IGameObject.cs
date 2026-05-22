using System.Numerics;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.GameObjects;

public interface IGameObject : IRenderable
{
    public bool IsVisible { get; }
    public Vector2 Coordinates { get; }
    public Texture2D texture { get; }
    
    public void Draw()
    {
        Raylib.DrawTexture(texture, (int)Coordinates.X, (int)Coordinates.Y, Color.White);
    }
}