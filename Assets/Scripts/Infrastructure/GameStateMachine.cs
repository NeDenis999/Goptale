using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.States;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(ICoroutineRunner coroutineRunner, SceneLoader sceneLoader, AllServices allServices)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, allServices, coroutineRunner),
                [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader,
                    allServices.Single<GameFactory>(),
                    allServices.Single<UIFactory>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
