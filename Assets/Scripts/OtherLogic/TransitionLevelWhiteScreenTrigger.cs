using Infrastructure.Services;
using Infrastructure.States;
using Player;
using Screens;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace OtherLogic
{
    public class TransitionLevelWhiteScreenTrigger : MonoBehaviour
    {
        [SerializeField] 
        private TransitionScreen _whileScreen;

        [SerializeField] 
        private string _level;
        
        [SerializeField] 
        private int _numberSpawnPoint;

        private ITransitionLevelService _transitionLevelService;
        private SaveService _saveService;
        private LoadingCurtain _loadingCurtain;

        [Inject]
        public void Construct(ITransitionLevelService transitionLevelService, SaveService saveService, LoadingCurtain loadingCurtain)
        {
            _transitionLevelService = transitionLevelService;
            _saveService = saveService;
            _loadingCurtain = loadingCurtain;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerPause playerPause))
                return;

            if (_saveService.LocalSavesData.WentToTheFirstArch)
                TransitLevel();
            else
                StartOpen(playerPause);
        }
        
        private void StartOpen(PlayerPause playerPause)
        {
            playerPause.OnPause();
                    
            _whileScreen.OpenEnded += OneTransitLevel;
            _whileScreen.Open();
        }

        private void OneTransitLevel()
        {
            _saveService.LocalSavesData.WentToTheFirstArch = true;
            _transitionLevelService.TransitLevel(_level);
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
