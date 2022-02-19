using System;
using Infrastructure.States;
using UnityEngine;

namespace Code
{
    public class BattleStateMachine : MonoBehaviour
    {
        [SerializeField]
        private BattleState _currentState;

        private void Start()
        {
            Initialize(_currentState);
        }

        private void Update()
        {
            _currentState?.Tick();
        }

        public void Initialize(BattleState startingState)
        {
            _currentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(BattleState newState)
        {
            _currentState.Exit();

            _currentState = newState;
            newState.Enter();
        }
    }

    public abstract class BattleState : MonoBehaviour, IBattleState
    {
        public virtual void Enter()
        {
            throw new NotImplementedException();
        }

        public virtual void Exit()
        {
            throw new NotImplementedException();
        }

        public virtual void Tick()
        {
            throw new NotImplementedException();
        }
    }
    
    public interface IBattleState
    {
        void Enter();
        void Exit();
        void Tick();
    }
}
