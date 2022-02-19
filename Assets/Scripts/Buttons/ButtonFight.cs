using UnityEngine;

namespace Buttons
{
    public class ButtonFight : ButtonBattle
    {
        [SerializeField] 
        private SwitchButtonsAttack _switchButtonsAttack;

        public override void Press()
        {
            base.Press();
            _switchButtonsAttack.Active();
        }
    }
}
