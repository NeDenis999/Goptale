using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader : MonoBehaviour
    {
        public IEnumerator LoadLevel(string nameLevel, Action onLoaded = null)
        {
            var waitLoadLevel = SceneManager.LoadSceneAsync(nameLevel);
            yield return waitLoadLevel;
            onLoaded?.Invoke(); }
    }
}
