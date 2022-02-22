using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public class TransitionLevelService : ITransitionLevelService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        private int _numberSpawnPoint = 0;
        private bool _isFirstTransition = true;
        
        public TransitionLevelService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void TransitLevel(string scene) => 
            SceneManager.LoadScene(scene);

        public void TransitLevel(string scene, Action action)
        {
            _coroutineRunner.StartCoroutine(TransitiLevel(scene, action));
        }

        public void SetNumberPoint(int numberSpawnPoint)
        {
            _isFirstTransition = false;
            _numberSpawnPoint = numberSpawnPoint;
        }

        public int GetNumberSpawnPoint()
        {
            if (_isFirstTransition)
                return 0;

            return _numberSpawnPoint;
        }

        IEnumerator TransitiLevel(string scene, Action action = null)
        {
            AsyncOperation waitLoadScene = SceneManager.LoadSceneAsync(scene);
            yield return waitLoadScene;
            action?.Invoke();
        }
    }
}