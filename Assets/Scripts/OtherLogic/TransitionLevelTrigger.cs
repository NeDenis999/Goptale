using Infrastructure.Services;
using Infrastructure.States;
using Player;
using Screens;
using UnityEngine;

namespace OtherLogic
{
    public class TransitionLevelTrigger : MonoBehaviour
    {
        [SerializeField] 
        private string _level;

        private ITransitionLevelService _levelService;
        private TransitionScreen _transitionScreen;

        public void Construct(ITransitionLevelService levelService, TransitionScreen transitionScreen)
        {
            _levelService = levelService;
            _transitionScreen = transitionScreen;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerPause playerPause))
                TransitLevel();
        }

        private void TransitLevel() => 
            _levelService.TransitLevel(_level, EndTransit);

        private void EndTransit() => 
            _transitionScreen.Open();
    }
}