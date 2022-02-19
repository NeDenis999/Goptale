using Text;
using UnityEngine;

namespace Buttons
{
    public class SwitchButtonsAttack : ButtonSwitch
    {
        private const string Vertical = "Vertical";
        private const string Cancel = "Cancel";

        [SerializeField] 
        private DialogueBattleWindow _dialogueWindow;
        
        [SerializeField] 
        private BattleButtonSwitch _battleButtonSwitch;
        
        protected override void PressProcessing()
        {
            if (Input.GetButtonDown(Vertical))
                Switch((int)Input.GetAxisRaw(Vertical));

            if (Input.GetButtonDown(Cancel))
                Back();
        }

        public override void Active()
        {
            base.Active();
            _dialogueWindow.HideTextMeshPro();
            gameObject.SetActive(true);
        }

        private void Back()
        {
            _dialogueWindow.ShowTextMeshPro();
            _battleButtonSwitch.Active();
            Deactivate();
        }

        protected override void Deactivate() => 
            gameObject.SetActive(false);
    }
}