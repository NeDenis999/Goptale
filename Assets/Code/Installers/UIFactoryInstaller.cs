using Infrastructure.Factory;
using Infrastructure.Services;
using Player;
using Zenject;

namespace Code.Installers
{
    public class UIFactoryInstaller : MonoInstaller
    {
        [Inject] 
        private IAssetProvider _assetProvider;
        
        [Inject] 
        private PlayerPause _playerPause;
        
        public override void InstallBindings()
        {
            IUIFactory uiFactory = new UIFactory(_assetProvider, _playerPause);
            
            Container.Bind<IUIFactory>().FromInstance(uiFactory).AsCached().NonLazy();
        }
    }
}