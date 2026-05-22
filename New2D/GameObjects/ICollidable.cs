using Raylib_cs;

namespace New2D.GameObjects;

public interface ICollidable
{
    public Rectangle Bounds { get; set; }
}