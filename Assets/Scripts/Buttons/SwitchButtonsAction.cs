using Text;
using UnityEngine;

namespace Buttons
{
    public class SwitchButtonsAction : ButtonSwitch
    {
        private const string Vertical = "Vertical";

        [SerializeField] 
        private DialogueBattleWindow _dialogueWindow;
        
        protected override void PressProcessing()
        {
            if (Input.GetButtonDown(Vertical))
                Switch((int)Input.GetAxisRaw(Vertical));
        }

        public override void Active()
        {
            base.Active();
            _dialogueWindow.HideTextMeshPro();
            gameObject.SetActive(true);
        }
    }
}