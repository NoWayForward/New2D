using Raylib_cs;

namespace New2D.Helpers;

public static class Common
{
    public static bool IsHovered(Rectangle rect)
    {
        return Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(),  rect);
    }

    public static string ProjectRoot { get; } = AppContext.BaseDirectory;
    
}