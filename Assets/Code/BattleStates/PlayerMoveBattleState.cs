using Buttons;
using Dialogues;
using Text;
using UnityEngine;
using Zenject;

namespace Code.BattleStates
{
    public class PlayerMoveBattleState : BattleState
    {
        [SerializeField] 
        private ButtonSwitch _buttonSwitch;

        [SerializeField] 
        private DialogueBattleWindow _dialogueWindow;

        [SerializeField] 
        private DialogueOneMessage _dialogue;
        
        [Inject]
        public void Construct(Determination determination)
        {
            determination.gameObject.SetActive(true);
        }

        public override void Enter()
        {
            _buttonSwitch.Active();
            _dialogueWindow.Show(_dialogue);
        }

        public override void Exit()
        {
            
        }

        public override void Tick()
        {
            
        }
    }
}