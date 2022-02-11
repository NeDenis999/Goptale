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
        private Transform spawnPoint;
        
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerPause>(
                _player, spawnPoint.position, Quaternion.identity, null);

            Container.Bind<PlayerPause>().FromInstance(playerInstance).AsCached().NonLazy();
        }
    }
}