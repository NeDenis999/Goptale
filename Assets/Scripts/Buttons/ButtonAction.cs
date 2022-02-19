using UnityEngine;

namespace Buttons
{
    public class ButtonAction : ButtonBattle
    {
        [SerializeField] 
        private SwitchButtonsAction _switchButtonsAction;

        public override void Press()
        {
            base.Press();
            _switchButtonsAction.Active();
        }
    }
}