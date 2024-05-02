using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.SceneLoaderSystem
{
    public class SceneLoader : IDisposable
    {
        private readonly string _rootSceneName;

        private Scene _currentScene;
        private string _currentSceneNameForLoad;
        private LoadSceneMode _currentLoadSceneMode;

        public SceneLoader(string rootSceneName)
        {
            _rootSceneName = rootSceneName;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Load(string sceneName, LoadSceneMode mode, IOperationBeforeLoading operation = null)
        {
            _currentSceneNameForLoad = sceneName;
            _currentLoadSceneMode = mode;

            if (operation == null)
            {
                SceneManager.LoadScene(_currentSceneNameForLoad, _currentLoadSceneMode);
                return;
            }

            operation.Executed += OnExecuted;
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (_currentScene.name != null && _currentScene.name != _rootSceneName)
                SceneManager.UnloadSceneAsync(_currentScene);

            _currentScene = scene;
        }

        private void OnExecuted(IOperationBeforeLoading operation)
        {
            operation.Executed -= OnExecuted;
            SceneManager.LoadScene(_currentSceneNameForLoad, _currentLoadSceneMode);
        }
    }
}