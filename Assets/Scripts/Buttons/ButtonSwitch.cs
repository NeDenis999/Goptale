using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    public class ButtonSwitch : MonoBehaviour
    {
        [SerializeField]
        private List<Button> _buttons;

        private void Start()
        {
            Active();
        }

        private void Update()
        {
            PressProcessing();
        }

        private void PressProcessing()
        {
            if (Input.GetButtonDown("Horizontal"))
                Switch();
        }

        private void Switch()
        {
            _buttons[0].NotSelected();
        }

        public void Active()
        {
            _buttons[0].Selected();
        }

        private void Deactivate()
        {
            
        }
    }
}