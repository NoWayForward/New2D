using System.Numerics;
using System.Runtime.CompilerServices;
using New2D.Helpers;
using New2D.Renderer;
using Raylib_cs;

namespace New2D.GameObjects;

public class Button(string label, Vector2 coordinates, Action onClick, bool shouldCenter = false)
    : IRenderable, IClickable
{
    public string Label {get; set;} = label;
    public bool IsHovered { get; set; } = false;
    public bool IsVisible { get; } = true;
    public Vector2 Coordinates { get; } = coordinates;
    public Action OnClick { get; set; } = onClick;
    public Rectangle Bounds { get; set; }
    
    public bool ShouldCenter { get; set; } = shouldCenter;
    public void Draw()
    {
        int xCoord =  (int)Coordinates.X;
        int labelWidth = Raylib.MeasureText(Label, 24);
        int recWidth = labelWidth + 16;
        int labelLeft = (recWidth - labelWidth) / 2;
        
        if (ShouldCenter) xCoord = (int)Raylib.GetScreenCenter().X - recWidth / 2;
        
        Bounds =  new Rectangle(xCoord,  Coordinates.Y, recWidth, 30);
        Raylib.DrawRectangle(xCoord, (int)Coordinates.Y, recWidth, 30, IsHovered? Color.Gray : Color.DarkGray);
        Raylib.DrawText(Label, xCoord + labelLeft, (int)Coordinates.Y + 3, 24, Color.White);
    }
}