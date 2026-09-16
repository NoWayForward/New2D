using System.Numerics;
using New2D.GameObjects;

namespace New2D.Scene;

public interface IWorldContext
{
    IReadOnlyList<ICollidable> Collidables { get; }
    Vector2 PlayerPosition { get; }
}