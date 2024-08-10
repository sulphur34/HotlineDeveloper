using Modules.LevelSelectionSystem;
using Modules.LevelsSystem;
using Modules.PressedButtonSystem;
using System.Linq;

namespace Module.ContinueLevelButtonSystem
{
    public class ContinueLevelButton : PressedButton
    {
        private Level _levelForLoad;
        private LevelsData _levels;
        private LevelSceneLoader _levelSceneLoader;

        internal void Init(LevelsData levels, LevelSceneLoader levelSceneLoader)
        {
            _levels = levels;
            _levelForLoad = _levels.Value.FindLast(level => level.IsLocked == false);

            if (_levelForLoad == null)
                _levelForLoad = _levels.Value[0];

            _levelSceneLoader = levelSceneLoader;
        }

        protected override void MakeOnClick()
        {
            _levels.ForLoad = (int)_levelForLoad.Number;
            _levelSceneLoader.Load((int)_levelForLoad.Number);
        }
    }
}
