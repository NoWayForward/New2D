using System.Numerics;
using New2D.GameObjects;
using New2D.Helpers;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.Scene;

public class MenuScene : Scene, IScene
{
    public void Load(Renderer.Renderer renderer)
    {
        int i = 0;
        RegisterObjects(new Button(
            label: "Continue",
            coordinates: new Vector2(60, 30),
            shouldCenter: true,
            onClick: () => {}
            ));
        i++;
        RegisterObjects(new Button(
            label: "New Game",
            coordinates: new Vector2(60, 30+60),
            shouldCenter: true,
            onClick: () => {GameState.GameState.ChangeScene(new TestLevelScene());}
        ));
        i++;
        RegisterObjects(new Button(
            label: "Level Select",
            coordinates: new Vector2(60, 30+(i*60)),
            shouldCenter: true,
            onClick: () => {Console.WriteLine("Level Select");}
        ));
        i++;
        RegisterObjects(new Button(
            label: "Exit",
            coordinates: new Vector2(60, 30+(i*60)),
            shouldCenter: true,
            onClick: () => { Console.WriteLine("Exit"); GameState.GameState.ShouldRun = false;}
        ));

        foreach (var renderable in Renderables)
        {
            renderer.Add(renderable, RenderLayer.foreground);
        }
    }

    public void Update()
    {
        this.Handle();
    }
}