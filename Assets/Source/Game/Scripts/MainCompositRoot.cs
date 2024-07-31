using Modules.Audio;
using Modules.FadeSystem;
using Modules.LeaderboardSystem;
using Modules.LevelsSystem;
using Modules.SavingsSystem;
using Modules.SceneLoaderSystem;
using VContainer;
using VContainer.Unity;

public class MainCompositRoot : LifetimeScope
{
    private const uint LevelsCount = 21;

    private readonly SaveSystem _saveSystem = new SaveSystem();

    private SaveData _saveData;

    public void SetData(SaveData saveData)
    {
        _saveData = saveData;
    }

    protected override void Configure(IContainerBuilder builder)
    {
        InitLevels(_saveData.LevelsData);
        builder.RegisterInstance(_saveData.LevelsData);
        builder.Register<SceneLoader>(Lifetime.Singleton);
        builder.Register<Leaderboard>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<Fade>();
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

    private void SetLocalization()
    {
        
    }
}