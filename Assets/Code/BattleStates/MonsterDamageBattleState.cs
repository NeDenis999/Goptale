using System.Collections;
using ModestTree;
using UnityEngine;
using Zenject;

namespace Code.BattleStates
{
    public class MonsterDamageBattleState : BattleState
    {
        [SerializeField] 
        private BattleStateMachine _battleStateMachine;

        [SerializeField] 
        private MonsterMoveBattleState _moveBattleState;
        
        [SerializeField] 
        private EnemyMonster enemyMonster;

        public YieldInstruction WaitMonsterTakeDamage;
        
        public override void Enter()
        {
            WaitMonsterTakeDamage = StartCoroutine(enemyMonster.TakeDamage());
        }

        public override void Exit()
        {
            _battleStateMachine.ChangeState(_moveBattleState);
        }

        public override void Tick()
        {
            
        }
    }
}
