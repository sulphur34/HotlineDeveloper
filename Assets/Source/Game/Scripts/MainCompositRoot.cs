using Modules.FadeSystem;
using Modules.LevelsSystem;
using Modules.PauseMenu;
using Modules.SavingsSystem;
using Modules.SceneLoaderSystem;
using VContainer;
using VContainer.Unity;

public class MainCompositRoot : LifetimeScope
{
    private const uint LevelsCount = 5;

    private readonly SaveSystem _saveSystem = new SaveSystem();

    protected override void Configure(IContainerBuilder builder)
    {
        _saveSystem.Load(data =>
        {
            SceneLoader sceneLoader = new SceneLoader();

            InitLevels(data.LevelsData);
            builder.RegisterInstance(data.LevelsData);
            builder.RegisterInstance(sceneLoader);
            builder.RegisterComponentInHierarchy<Fade>();
            sceneLoader.Load(SceneName.Menu.ToString());
        });
    }

    private void InitLevels(LevelsData levels)
    {
        if (levels.Value.Count > 0)
            return;

        _saveSystem.Save(data =>
        {
            for (int i = 0; i < LevelsCount; i++)
            {
                levels.Value.Add(new Level());
                uint levelNumber = (uint)i + 1;
                levels.Value[i].SetNumber(levelNumber);

                if (i == 0)
                    levels.Value[i].Unlock();
            }

            data.LevelsData = levels;
        });
    }
}