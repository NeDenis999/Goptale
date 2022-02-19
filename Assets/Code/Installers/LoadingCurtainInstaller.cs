using Screens;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class LoadingCurtainInstaller : MonoInstaller
    {
        [SerializeField] 
        private LoadingCurtain _loadingCurtain;
        
        public override void InstallBindings()
        {
            var loadingCurtainInstaller = Container.InstantiatePrefabForComponent<LoadingCurtain>(_loadingCurtain, transform);
            
            DontDestroyOnLoad(loadingCurtainInstaller);
            
            Container
                .Bind<LoadingCurtain>()
                .FromInstance(loadingCurtainInstaller)
                .AsSingle();
        }
    }
}