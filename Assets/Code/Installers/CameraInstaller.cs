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
        
        [SerializeField] 
        private float _speed = 1f;

        [SerializeField] 
        private float _maxDown = -100f;
        
        [SerializeField] 
        private float _maxLeft = -100f;
        
        [SerializeField] 
        private float _maxRight = 100f;
        
        [SerializeField] 
        private float _maxUp = 100f;

        
        [Inject]
        private PlayerPause _player;

        public override void InstallBindings()
        {
            var spawnPoint = _player.transform;
            
            var cameraInstance = Container.InstantiatePrefabForComponent<CameraMovement>(
                _cameraMovement, spawnPoint.position, Quaternion.identity, null);
            
            cameraInstance.Construct(_player.transform);
            cameraInstance.SetBoundaries(_maxDown, _maxLeft, _maxRight, _maxUp, _speed);

            Container
                .Bind<CameraMovement>()
                .FromInstance(cameraInstance)
                .AsSingle();
        }
    }
}
