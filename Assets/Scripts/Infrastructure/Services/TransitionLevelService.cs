using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public class TransitionLevelService : ITransitionLevelService
    {
        private ICoroutineRunner _coroutineRunner;
        
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

        IEnumerator TransitiLevel(string scene, Action action)
        {
            AsyncOperation waitLoadScene = SceneManager.LoadSceneAsync(scene);
            yield return waitLoadScene;
            action.Invoke();
        }
    }
}