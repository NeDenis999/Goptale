using Infrastructure.Services;
using Infrastructure.States;
using Player;
using Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OtherLogic
{
    public class TransitionLevelWhiteScreenTrigger : MonoBehaviour
    {
        [SerializeField] private string _level;

        [SerializeField] private TransitionScreen _whileScreen;

        private ITransitionLevelService _levelService;

        public void Construct(ITransitionLevelService levelService)
        {
            _levelService = levelService;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerPause playerPause))
                return;

            playerPause.OnPause();
            
            if (!_whileScreen) return;
            _whileScreen.OpenEnded += TransitLevel;
            _whileScreen.Open();
        }

        private void TransitLevel()
        {
            _levelService.TransitLevel(_level);
        }
    }
}
