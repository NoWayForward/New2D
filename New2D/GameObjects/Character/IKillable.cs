namespace New2D.GameObjects.Character;

public interface IKillable
{
    public int Health { get; protected set; }
    public void Hurt(int damage);
    public void Heal(int heal);
}