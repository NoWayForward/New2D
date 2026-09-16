using System.Numerics;
using New2D.GameObjects.Character.NPC.Enemy;
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
    
    public Player Player { get; } = new Player(new Vector2(15, 15));

    public TestLevelObjects(IWorldContext worldContext)
    {
        foreground.Add(Player);
        foreground.Add(new Block(new Rectangle(-1,0,1,300)));
        foreground.Add(new Block(new Rectangle(615,0,1,300)));
        foreground.Add(new Block(new Rectangle(0,300,615,1)));
        foreground.Add(new Block(new Rectangle(0,-1,615,1)));
        foreground.Add(new Block(new Rectangle(100,100,20,15)));
        foreground.Add(new Enemy(worldContext, new Vector2(200,100)));
    }
}