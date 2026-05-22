using Raylib_cs;

namespace New2D.Renderer;

public class Renderer
{
    private List<IRenderable> background = new();
    private List<IRenderable> midground = new();
    private List<IRenderable> foreground = new();

    private Rectangle topLeftBounds;
    private Rectangle bottomRightBounds;

    public void Add(IRenderable renderable, RenderLayer layer)
    {
        switch (layer)
        {
            case RenderLayer.background: 
                background.Add(renderable);
                break;
            case RenderLayer.midground: 
                midground.Add(renderable);
                break;
            case RenderLayer.foreground: 
                foreground.Add(renderable); 
                break;
            default: throw new Exception("Unknown layer called in add " + layer.ToString());
        }
    }

    public void Draw()
    {
        foreach (var layer in new[] { background, midground, foreground })
        foreach (var renderable in layer.Where(IsInBounds))
            renderable.Draw();
    }

    public void RemoveObject(IRenderable renderable, RenderLayer layer)
    {
        switch (layer)
        {
            case RenderLayer.background: background.Remove(renderable); break;
            case RenderLayer.midground: midground.Remove(renderable); break;
            case RenderLayer.foreground: foreground.Remove(renderable); break;
            default: throw new Exception("Unknown layer called in remove " + layer.ToString());
        }
    }
/// <summary>
/// Use at stage change. Clears board for fresh start
/// </summary>
    public void Clear()
    {
        background.Clear();
        midground.Clear();
        foreground.Clear();
    }

    private bool IsInBounds(IRenderable renderable)
    {
        return (
            renderable.Coordinates.X > topLeftBounds.X &&
            renderable.Coordinates.X < bottomRightBounds.X &&
            renderable.Coordinates.Y > topLeftBounds.Y &&
            renderable.Coordinates.Y < bottomRightBounds.Y);
    }
}