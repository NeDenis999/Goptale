using Infrastructure.Services;
using Player;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerPause _player;

        [SerializeField] 
        private Transform[] _spawnPoints;

        private ITransitionLevelService _transitionLevelService;
        
        [Inject]
        public void Construct(ITransitionLevelService transitionLevelService)
        {
            _transitionLevelService = transitionLevelService;
        }
        
        public override void InstallBindings()
        {
            var spawnPoint = _spawnPoints[_transitionLevelService.GetNumberSpawnPoint()];
            
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerPause>(
                _player, spawnPoint.position, Quaternion.identity, null);

            Container
                .Bind<PlayerPause>()
                .FromInstance(playerInstance)
                .AsSingle();
        }
    }
}