using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class SoundInstaller : MonoInstaller
    {
        [SerializeField]
        private SoundService _soundService;
        
        public override void InstallBindings()
        {
            Container
                .Bind<SoundService>()
                .FromInstance(_soundService)
                .AsSingle();
        }
    }
}
