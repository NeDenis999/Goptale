using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class DeterminationInstaller : MonoInstaller
    {
        [SerializeField] 
        private Determination _determination;
        
        public override void InstallBindings()
        {
            var determinationInstaller = Container.InstantiatePrefabForComponent<Determination>(
                _determination,
                transform
            );
            
            determinationInstaller.gameObject.SetActive(false);
            
            Container
                .Bind<Determination>()
                .FromInstance(determinationInstaller)
                .AsSingle();
        }
    }
}
