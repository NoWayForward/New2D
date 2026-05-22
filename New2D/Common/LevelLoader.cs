using System.Runtime.Serialization.Json;
using New2D.Renderer;

namespace New2D.Helpers;

public class LevelLoader
{
    public List<IRenderable> LoadRenderables(String filePath)
    {
        String json = File.ReadAllText(filePath);
        throw new NotImplementedException();
        // return new List<IRenderable>();
    }
}