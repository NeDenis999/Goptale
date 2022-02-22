using System.Collections.Generic;
using UnityEngine;

namespace Buttons
{
    public class ButtonSwitch : MonoBehaviour
    {
        protected const string Horizontal = "Horizontal";
        private const string Submit = "Submit";
        
        [SerializeField]
        private List<Button> _buttons;

        private int _currentNumberButton;
        
        private void Update()
        {
            PressProcessing();
        }

        public virtual void Active()
        {
            enabled = true;
            
            if (_buttons.Count > 0)
                _buttons[ButtonFirstNumber()].Selected();
        }

        protected virtual void PressProcessing()
        {
            if (Input.GetButtonDown(Horizontal))
                Switch((int)Input.GetAxisRaw(Horizontal));

            if (Input.GetButtonDown(Submit))
                PressButton();
        }

        protected virtual void Deactivate()
        {
            _buttons[_currentNumberButton].NotSelected();
            enabled = false;
        }

        protected void Switch(int direction)
        {
            if (NextButtonNumber(direction) <= ButtonEndNumber() && NextButtonNumber(direction) >= ButtonFirstNumber())
            {
                _buttons[_currentNumberButton].NotSelected();
                _buttons[NextButtonNumber(direction)].Selected();
                _currentNumberButton = NextButtonNumber(direction);
            }
        }

        protected void PressButton()
        {
            _buttons[_currentNumberButton].Press();
            Deactivate();
        }

        private int NextButtonNumber(int direction)
        {
            return _currentNumberButton + direction;
        }

        private int ButtonEndNumber()
        {
            return _buttons.Count - 1;
        }

        private int ButtonFirstNumber()
        {
            return 0;
        }
    }
}