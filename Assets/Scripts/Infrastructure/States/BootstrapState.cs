using Infrastructure.Factory;
using Infrastructure.Services;

namespace Infrastructure.States
{
    public class BootstrapState : IPayloadedState<bool>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices allServices, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = allServices;
            _coroutineRunner = coroutineRunner;

            RegisterService();
        }

        public void Enter(bool isBattle)
        {
            if (!isBattle)
                _gameStateMachine.Enter<LoadLevelState, string>("");
            else
                _gameStateMachine.Enter<LoadLevelBattleState>();
        }

        public void Exit()
        {
        
        }

        private void RegisterService()
        {
            _allServices.RegisterService(new AssetProvider());
            _allServices.RegisterService(new TransitionLevelService(_coroutineRunner));
            _allServices.RegisterService(new GameFactory(_allServices.Single<AssetProvider>()));
            _allServices.RegisterService(new AllGameObjectsService(_allServices.Single<TransitionLevelService>(), _allServices.Single<GameFactory>()));
            _allServices.RegisterService(new PauseServices(_allServices.Single<AllGameObjectsService>().PlayerPause()));
            _allServices.RegisterService(new UIFactory(_allServices.Single<AssetProvider>(), _allServices.Single<AllGameObjectsService>().PlayerPause()));
        }
    }
}
