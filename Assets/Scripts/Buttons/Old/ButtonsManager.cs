using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Buttons.Old
{
    public class ButtonsManager : ButtonManagerBase
    {
        [SerializeField] private Vector2 _offset = new Vector2(0, 0);
        [SerializeField] private int _verticalMove = 0;
        [SerializeField] private int _horizontalMove = 1;
        [SerializeField] private UnityEvent _event;
        [SerializeField] private bool _isActive = false;
        [SerializeField] private DeterminationChangePosition _determination;

        protected ButtonManager _previousButtonManager;
        private int _activeCountButton = 0;
        protected List<ButtonBase> _buttons = new List<ButtonBase>();

        private void Awake()
        {
            StartCoroutine(SearchButton());
        }

        public void SetIsActive(bool active)
        {
            _isActive = active;

            if (_isActive)
                StartCoroutine(SearchButton());
        }

        public void SetPreviousButtonManager(ButtonManager previousButtonManager = null)
        {
            _previousButtonManager = previousButtonManager;
        }

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (_isActive)
            {
                if (_buttons.Count != 0)
                {
                    if (Input.GetButtonDown("Horizontal"))
                        StartCoroutine(Switching((int)Input.GetAxisRaw("Horizontal") * _horizontalMove));
                    if (Input.GetButtonDown("Vertical"))
                        StartCoroutine(Switching(-(int)Input.GetAxisRaw("Vertical") * _verticalMove));

                    if (Input.GetButtonDown("Submit"))
                        StartCoroutine(UseButton());
                }

                if (Input.GetButtonDown("Cancel"))
                    StartCoroutine(Back());
            }
        }

        private IEnumerator SearchButton()
        {
            if (!GetComponentInChildren<ButtonBase>()) StopCoroutine(SearchButton());

            yield return new WaitForEndOfFrame();

            _buttons.Clear();

            foreach (ButtonBase button in GetComponentsInChildren<ButtonBase>())
            {
                if (button.gameObject.activeSelf)
                    _buttons.Add(button);
            }

            if (_isActive && _buttons.Count != 0)
            {
                StartCoroutine(Switching());
            }
        }

        public void SetDefaultCount()
        {
            _activeCountButton = 0;
        }

        private IEnumerator Switching(int count = 0)
        {
            if (_isActive)
            {
                _determination.SetPosition(_buttons[_activeCountButton].transform.position, _offset);
                yield return new WaitForEndOfFrame();
                if ((_activeCountButton + count) >= 0 && (_activeCountButton + count) < _buttons.Count)
                    _activeCountButton += count;

                foreach (var button in _buttons) 
                    ChangeColor(button, new Color32(255, 130, 41, 255));

                ChangeColor(_buttons[_activeCountButton], new Color32(255, 255, 0, 255));

                _determination.SetPosition(_buttons[_activeCountButton].transform.position, _offset);
            }
        }

        private void ChangeColor(ButtonBase button, Color32 color32)
        {
            button.GetComponentsInChildren<Image>()[0].color = color32;
            button.GetComponentsInChildren<Image>()[1].color = color32;
            button.GetComponentInChildren<TextMeshProUGUI>().color = color32;
        }

        private IEnumerator UseButton()
        {
            if (_buttons[_activeCountButton].eventCheck)
            {
                yield return new WaitForEndOfFrame();
                _buttons[_activeCountButton].UseIvent(gameObject.GetComponent<ButtonManager>());
                SetIsActive(false);
                if (_determination)
                    Destroy(_determination.gameObject);
            }
        }

        private IEnumerator Back()
        {
            if (_event.GetPersistentEventCount() == 0 && !_previousButtonManager)
            {

            }
            else
            {
                SetIsActive(false);
                yield return new WaitForEndOfFrame();

                if (_previousButtonManager)
                {
                    _previousButtonManager.SetIsActive(true);
                }

                if (_determination) Destroy(_determination.gameObject);
                _event.Invoke();
            }
        }
    }
}
