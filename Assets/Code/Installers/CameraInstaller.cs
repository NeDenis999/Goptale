using OtherLogic;
using Player;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] 
        private CameraMovement _cameraMovement;
        
        [Inject]
        private PlayerPause _player;

        public override void InstallBindings()
        {
            var spawnPoint = _player.transform;
            
            var cameraInstance = Container.InstantiatePrefabForComponent<CameraMovement>(
                _cameraMovement, spawnPoint.position, Quaternion.identity, null);
            
            cameraInstance.Construct(_player.transform);

            Container.Bind<CameraMovement>().FromInstance(cameraInstance).AsCached().NonLazy();
        }
    }
}
