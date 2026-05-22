using Raylib_cs;

namespace New2D.Helpers;

public interface IClickable
{
    public bool IsHovered { get; set;  }
    Rectangle Bounds { get; protected set;  }
    Action OnClick { get; set; }
}