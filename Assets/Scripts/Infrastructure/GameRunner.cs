using UnityEngine;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField]
        private GameBootstrapper _gameBootstrapperPrefab;

        private void Awake()
        {
            var gameBootstrapper = FindObjectOfType<GameBootstrapper>();

            if (gameBootstrapper != null)
                return;

            Instantiate(_gameBootstrapperPrefab);
        }
    }
}
