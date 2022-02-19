using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class StartBattleInstall : MonoInstaller
    {
        [SerializeField] 
        private StartBattleService _startBattleService;
        
        public override void InstallBindings()
        {
            var startBattleInstaller = Container.InstantiatePrefabForComponent<StartBattleService>(
                _startBattleService,
                transform
            );
            
            Container
                .Bind<StartBattleService>()
                .FromInstance(startBattleInstaller)
                .AsSingle();
        }
    }
}
