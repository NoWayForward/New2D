using System.Numerics;
using New2D.GameObjects.Character.Player;
using New2D.GameObjects.Enviornment;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.Scene;

public class TestLevelObjects
{    
    protected internal List<IRenderable> foreground = new List<IRenderable>();
    protected internal List<IRenderable> midground = new List<IRenderable>();
    protected internal List<IRenderable> background = new List<IRenderable>();
    
    public TestLevelObjects()
    {
        foreground.Add(new Player(new Vector2(15,15)));
        foreground.Add(new Block(new Rectangle(60,15,20,15)));
    }
    
}