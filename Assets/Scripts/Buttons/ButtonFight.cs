using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class ButtonFight : Button
    {
        [SerializeField]
        private Image _window;
        
        [SerializeField]
        private Image _icon;
        
        [SerializeField]
        private TextMeshProUGUI _text;

        private readonly Color32 red = new Color32(255, 130, 41, 255);
        private readonly Color32 yellow = new Color32(255, 255, 0, 255);

        public override void Press()
        {
            base.Press();
            ChangeColor(red);
        }

        public override void Selected()
        {
            base.Selected();
            ChangeColor(yellow);
        }

        public override void NotSelected()
        {
            base.NotSelected();
            ChangeColor(red);
        }

        private void ChangeColor(Color32 color32)
        {
            _window.color = color32;
            _icon.color = color32;
            _text.color = color32;
        }
    }
}
