// See https://aka.ms/new-console-template for more information

using New2D.GameState;
using New2D.Scene;
using Raylib_cs;

MenuScene menu = new MenuScene();
Raylib.InitWindow(615,300,"Game Start");
Raylib.SetTargetFPS(60);
GameState.InitScene(menu);
while (GameState.ShouldRun && !Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    GameState.Update();
    Raylib.EndDrawing();
}
GameState.Dispose();
Raylib.CloseWindow();