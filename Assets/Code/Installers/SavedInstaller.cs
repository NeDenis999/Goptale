using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class SavedInstaller : MonoInstaller
    {
        [SerializeField] 
        private LocalSavesData _localSavesData;
        
        public override void InstallBindings()
        {
            var saveService = new SaveService(_localSavesData);
            
            Container
                .Bind<SaveService>()
                .FromInstance(saveService)
                .AsSingle();
        }
    }
}