using System.Numerics;
using New2D.GameObjects;
using New2D.Helpers;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.Scene;

public class TestLevelScene : Scene, IScene
{
    private TestLevelObjects objects =  new TestLevelObjects();
    //TODO: Fix this structure. Currently breaks with non renderable types
    public void Load(Renderer.Renderer renderer)
    {
        RegisterObjects(objects);
        foreach (IRenderable renderable in objects.foreground)
        {
            renderer.Add(renderable, RenderLayer.foreground);
            RegisterObjects(renderable);
        }
        foreach (IRenderable renderable in objects.midground)
        {
            renderer.Add(renderable, RenderLayer.midground);
            RegisterObjects(renderable);
        }
        foreach (IRenderable renderable in objects.background)
        {
            renderer.Add(renderable, RenderLayer.background);
            RegisterObjects(renderable);
        } 
    }

    public void Update()
    {
        this.Handle();
    }
}