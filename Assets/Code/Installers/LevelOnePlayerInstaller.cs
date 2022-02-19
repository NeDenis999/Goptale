using Infrastructure.Services;
using Player;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class LevelOnePlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerPause _player;

        [SerializeField] 
        private PlayerPause _playerLay;

        [SerializeField] 
        private Transform[] _spawnPoints;

        [SerializeField] 
        private Transform _firstPoint;
        
        private ITransitionLevelService _transitionLevelService;
        private SaveService _saveService;
        
        [Inject]
        public void Construct(ITransitionLevelService transitionLevelService, SaveService saveService)
        {
            _transitionLevelService = transitionLevelService;
            _saveService = saveService;
        }
        
        public override void InstallBindings()
        {
            var playerPrefab = _saveService.LocalSavesData.WentToTheFirstArch ? _player : _playerLay;
            var spawnPoint = _saveService.LocalSavesData.WentToTheFirstArch ? _spawnPoints[_transitionLevelService.GetNumberSpawnPoint()] : _firstPoint;
            
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerPause>(
                playerPrefab, spawnPoint.position, Quaternion.identity, null);

            Container
                .Bind<PlayerPause>()
                .FromInstance(playerInstance)
                .AsSingle();
        }
    }
}