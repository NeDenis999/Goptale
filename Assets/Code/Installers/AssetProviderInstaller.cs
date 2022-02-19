using Infrastructure.Services;
using Zenject;

namespace Code.Installers
{
    public class AssetProviderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            IAssetProvider assetProvider = new AssetProvider();
            
            Container
                .Bind<IAssetProvider>()
                .FromInstance(assetProvider)
                .AsCached()
                .NonLazy();
        }
    }
}