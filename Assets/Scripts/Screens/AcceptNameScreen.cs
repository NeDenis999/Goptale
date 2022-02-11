using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AcceptNameScreen : Screen
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _stepColor;
        [SerializeField] private Color32 _endColor;
        [SerializeField] private SceneSwitch _sceneSwitch;

        private float _startAlpha;
        private float _currentAlpha;
        private bool _trigger;

        private void Awake()
        {
            _startAlpha = 0;
            _currentAlpha = _startAlpha;
        }

        public void ActivateTrigger() => 
            _trigger = true;

        private void Update()
        {
            ChangeAlpha();
        }

        private void ChangeAlpha()
        {
            if (_trigger)
            {
                if (_currentAlpha < 1)
                    _currentAlpha += _stepColor * Time.deltaTime / 255;
                else
                {
                    _trigger = false;
                    StartCoroutine(StartScene());
                }
            }
            
            _image.color = new Color(1, 1, 1, _currentAlpha);
        }

        private IEnumerator StartScene()
        {
            yield return new WaitForSeconds(1);
            _sceneSwitch.ChangeScene("Levl1");
        }
    }
}
