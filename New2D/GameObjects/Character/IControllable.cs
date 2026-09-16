namespace New2D.GameObjects.Character;

public interface IControllable
{
    public void ControlX();
    public void ControlY();
    public bool UpdatedX { get; }
    public bool UpdatedY { get; }

    public void Revert();
}