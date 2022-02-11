using UnityEngine;

namespace Screens
{
    public class ChoiceNameScreen : Screen
    {
        [SerializeField] private ButtonManager _lettersBig;
        [SerializeField] private GameObject _name;
        
        public override void Open()
        {
            base.Open();
            _lettersBig.SetIsActive(true);
            _name.SetActive(true);
        }
    }
}
