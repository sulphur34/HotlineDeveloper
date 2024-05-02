using Modules.LevelsSystem;
using Modules.SavingsSystem;
using Modules.SceneLoaderSystem;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class MainCompositRoot : LifetimeScope
{
    private const string RootSceneName = "RootScene";

    private readonly SaveSystem _saveSystem = new SaveSystem();

    private SceneLoader _sceneLoader;

    protected override void OnDestroy()
    {
        _sceneLoader.Dispose();
    }

    protected override void Configure(IContainerBuilder builder)
    {
        _saveSystem.Load(data =>
        {
            Level lastLoadedLevel = new Level();
            lastLoadedLevel.SetNumber(data.CurrentLevel);
            builder.RegisterInstance(lastLoadedLevel);

            _sceneLoader = new SceneLoader(RootSceneName);
            builder.RegisterInstance(_sceneLoader);
        });
    }
}