using Infrastructure.Services;
using Infrastructure.States;
using Player;
using Screens;
using UnityEngine;
using Zenject;

namespace OtherLogic
{
    public class TransitionLevelTrigger : MonoBehaviour
    {
        [SerializeField] 
        private string _level;
        
        [SerializeField] 
        private int _numberSpawnPoint;

        private ITransitionLevelService _transitionLevelService;
        private LoadingCurtain _loadingCurtain;

        [Inject]
        public void Construct(ITransitionLevelService transitionLevelService, LoadingCurtain loadingCurtain)
        {
            _transitionLevelService = transitionLevelService;
            _loadingCurtain = loadingCurtain;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerPause playerPause))
                TransitLevel();
        }

        private void TransitLevel()
        {
            _loadingCurtain.Show();
            _transitionLevelService.SetNumberPoint(_numberSpawnPoint);
            _transitionLevelService.TransitLevel(_level, EndTransit);
        }

        private void EndTransit() =>
            _loadingCurtain.Hide();
    }
}