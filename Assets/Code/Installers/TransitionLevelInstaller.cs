using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class TransitionLevelInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            ITransitionLevelService transitionLevelService = new TransitionLevelService(this);

            Container
                .Bind<ITransitionLevelService>()
                .FromInstance(transitionLevelService)
                .AsSingle();
        }
    }
}
