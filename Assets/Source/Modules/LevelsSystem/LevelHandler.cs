using UnityEngine;
using VContainer;

namespace Modules.LevelsSystem
{
    public class LevelHandler : MonoBehaviour
    {
        private Level _level;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
                _level.Complete();
        }

        [Inject]
        private void Constructe(LevelsData levels)
        {
            _level = levels.Value[levels.ForLoad - 1];
        }
    }
}
