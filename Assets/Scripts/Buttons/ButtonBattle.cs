using Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Buttons
{
    public class ButtonBattle : Button
    {
        [SerializeField]
        private Image _window;
        
        [SerializeField]
        private Image _icon;
        
        [SerializeField]
        private TextMeshProUGUI _text;

        private readonly Color32 red = new Color32(255, 130, 41, 255);
        private readonly Color32 yellow = new Color32(255, 255, 0, 255);

        private Determination _determination;

        [Inject]
        public void Construct(Determination determination)
        {
            _determination = determination;
        }
        
        public override void Press()
        {
            base.Press();
            NotSelected();
        }

        public override void Selected()
        {
            base.Selected();
            ChangeColor(yellow);
            _icon.gameObject.SetActive(false);
            _determination.transform.position = _icon.transform.position;
        }

        public override void NotSelected()
        {
            base.NotSelected();
            ChangeColor(red);
            _icon.gameObject.SetActive(true);
        }

        private void ChangeColor(Color32 color32)
        {
            _window.color = color32;
            _text.color = color32;
        }
    }
}