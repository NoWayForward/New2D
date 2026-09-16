using System.Numerics;
using New2D.GameObjects;
using New2D.Helpers;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.Scene;

public class TestLevelScene : Scene, IScene, IWorldContext
{
    private TestLevelObjects objects;

    public TestLevelScene()
    {
        objects = new TestLevelObjects(this);
    }

    //TODO: Fix this structure. Currently breaks with non renderable types
    public void Load(Renderer.Renderer renderer)
    {
        RegisterObjects(objects);
        foreach (IRenderable renderable in objects.foreground)
        {
            renderer.Add(renderable, RenderLayer.foreground);
            this.RegisterObjects(renderable);
        }
        foreach (IRenderable renderable in objects.midground)
        {
            renderer.Add(renderable, RenderLayer.midground);
            this.RegisterObjects(renderable);
        }
        foreach (IRenderable renderable in objects.background)
        {
            renderer.Add(renderable, RenderLayer.background);
            this.RegisterObjects(renderable);
        } 
    }

    public void Update()
    {
        this.Handle();
    }

    public IReadOnlyList<ICollidable> Collidables => base.Collidables;
    public Vector2 PlayerPosition => objects.Player.Coordinates;
}