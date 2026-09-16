using Raylib_cs;

namespace New2D.Helpers;

public static class Common
{
    public static bool IsHovered(Rectangle rect)
    {
        return Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(),  rect);
    }

    public static string ProjectRoot { get; } = AppContext.BaseDirectory;

    public static GameStatus gameStatus { get; set; } = GameStatus.gameRunning;

    public static bool IsHeadless { get; set; } = false;
}