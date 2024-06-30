using UnityEngine.SceneManagement;

namespace Modules.SceneLoaderSystem
{
    public class SceneLoader
    {
        private string _currentSceneNameForLoad;

        public void Load(string sceneName, IOperationBeforeLoading operation = null)
        {
            _currentSceneNameForLoad = sceneName;

            if (operation == null)
            {
                SceneManager.LoadScene(_currentSceneNameForLoad);
                return;
            }

            operation.Executed += OnExecuted;
        }

        private void OnExecuted(IOperationBeforeLoading operation)
        {
            operation.Executed -= OnExecuted;
            SceneManager.LoadScene(_currentSceneNameForLoad);
        }
    }
}