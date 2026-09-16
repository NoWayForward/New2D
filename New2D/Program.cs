using New2D.GameState;
using New2D.Helpers;
using New2D.Scene;
using Raylib_cs;

Common.IsHeadless = args.Contains("--headless");

if (Common.IsHeadless) Raylib.SetConfigFlags(ConfigFlags.HiddenWindow);
Raylib.InitWindow(615, 300, "Game Start");
if (!Common.IsHeadless) Raylib.SetTargetFPS(60);

IScene startScene = Common.IsHeadless ? new TestLevelScene() : new MenuScene();
GameState.InitScene(startScene);

while (GameState.ShouldRun && !Raylib.WindowShouldClose())
{
    if (!Common.IsHeadless)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
    }
    GameState.Update();
    if (!Common.IsHeadless)
        Raylib.EndDrawing();
}

GameState.Dispose();
Raylib.CloseWindow();
