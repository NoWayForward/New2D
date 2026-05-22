namespace New2D.Scene;

public interface IScene
{
    void Load(Renderer.Renderer renderer);
    void Unload(Renderer.Renderer renderer);
    void Update();
}