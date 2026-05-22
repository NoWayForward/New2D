namespace New2D.GameState;

public static class GameState
{
    public static bool ShouldRun = true;
    
    private static Scene.IScene currentScene;
    private static Renderer.Renderer renderer;

    public static void InitScene(Scene.IScene scene)
    {
        renderer = new Renderer.Renderer();
        currentScene = scene;
        currentScene.Load(renderer);
    }
    public static void ChangeScene(Scene.IScene newScene)
    {
        currentScene.Unload(renderer);
        currentScene = newScene;
        currentScene.Load(renderer);
    }

    public static void Dispose()
    {
        currentScene.Unload(renderer);
    }
    public static void Update() =>  currentScene.Update();
}