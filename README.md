# New2D

A 2D game framework built on [Raylib-cs](https://github.com/chrisdill/raylib-cs) (.NET 8).

## Getting started

```bash
dotnet build   # Build the project
dotnet run     # Build and run the game
```

## Architecture

The game loop in `Program.cs` is minimal: init a scene, then call `game.Update()` each frame inside Raylib's draw block.

### Core flow

`GameState` owns the `Renderer` and the active `IScene`. Calling `InitScene` or `ChangeScene` invokes `Load`/`Unload` on the outgoing and incoming scenes, which is where scenes register/deregister their objects with the renderer. `GameState.Update()` delegates to the current scene's `Update()` each frame.

### Rendering

`Renderer` maintains three ordered lists — `background`, `midground`, `foreground` — each holding `IRenderable` objects. `Draw()` iterates all three in order, skipping objects outside the camera bounds. Objects register themselves with `Renderer.Add(renderable, layer)` during scene `Load` and are removed via `Renderer.RemoveObject` or `Renderer.Clear()` during `Unload`.

`IRenderable` requires: `Draw()`, `isVisible`, and `coordinates` (a Raylib `Rectangle`).

### Scenes

Scenes implement `IScene` (`Load`, `Unload`, `Update`). A scene maintains its own `List<IRenderable>` and `List<IClickable>`. During `Update`, the scene handles input polling (mouse position, click detection via Raylib) and calls `Draw()` on each renderable.

### Game objects

`GameObject` (abstract) implements `IRenderable` and holds a `Texture2D` + `Rectangle` coordinates. `Button` (abstract, `New2D/UiElements/Button.cs`) implements both `IRenderable` and `IClickable` — requires `Label` and `OnClick` to be set via required properties.

`IClickable` requires: `isHovered`, `bounds` (Rectangle), and `OnClick` (Action).

### Level loading

`LevelLoader` (`New2D/Helpers/LevelLoader.cs`) is stubbed — JSON parsing from `Levels/*.json` is not yet implemented. Level files define scene content as JSON with typed action strings.
