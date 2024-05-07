using Modules.FadeSystem;
using Modules.LevelsSystem;
using Modules.SavingsSystem;
using Modules.SceneLoaderSystem;
using System.Collections.Generic;
using System.Linq;
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
            InitLevels(data.Levels);
            Level lastLoadedLevel = data.Levels.FirstOrDefault(level => level.Number == data.CurrentLevel);
            builder.RegisterInstance(lastLoadedLevel);

            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.RegisterInstance(data.Levels);
            builder.RegisterComponentInHierarchy<Fade>();
        });
    }

    private void InitLevels(List<Level> levels)
    {
        if (levels.Count > 0)
            return;

        _saveSystem.Save(data =>
        {
            for (int i = 0; i < LevelsCount; i++)
            {
                data.Levels.Add(new Level());
                uint levelNumber = (uint)i + 1;
                data.Levels[i].SetNumber(levelNumber);

                if (i == 0)
                    data.Levels[i].Unlock();
            }
        });
    }
}