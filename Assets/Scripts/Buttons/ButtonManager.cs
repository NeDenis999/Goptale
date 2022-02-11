using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ButtonManager : ButtonManagerBase
{
    [SerializeField] private Vector2 _offset = new Vector2(0, 0);
    [SerializeField] private int _verticalMove = 0;
    [SerializeField] private int _horizontalMove = 1;
    [SerializeField] private UnityEvent _event;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private bool _useDetermination = true;
    [SerializeField] private bool _useColor = false;
    [SerializeField] private Color32 _enableColor = new Color32(255, 255, 0, 255);
    [SerializeField] private Color32 _disableColor = new Color32(255, 255, 255, 255);
    [SerializeField] private bool _transition = true;
    [SerializeField] private UnityEvent _eventLimitUp;
    [SerializeField] private UnityEvent _eventLimitDown;
    [SerializeField] private UnityEvent _eventLimitRight;
    [SerializeField] private UnityEvent _eventLimitLeft;

    private DeterminationChangePosition _determinationPrefab;
    private DeterminationChangePosition _determination;
    protected ButtonManager _previousButtonManager;
    private int _activeCountButton = 0;
    private List<ButtonBase> _buttons = new List<ButtonBase>();

    public ButtonBase ActiveButton => _buttons[_activeCountButton];

    private void Awake()
    {
        if (_useDetermination)
        {
            while (!_determinationPrefab)
            {
                _determinationPrefab = Resources.Load<DeterminationChangePosition>("Determination");
            }
        }

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
        if (!GetComponentInChildren<ButtonBase>())
            StopCoroutine(SearchButton());

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
            if (_useDetermination)
            {
                while (!_determination)
                {
                    _determination = Instantiate<DeterminationChangePosition>(_determinationPrefab, _buttons[_activeCountButton].transform.position + (Vector3)_offset, Quaternion.identity, transform);
                }

                _determination.SetPosition(_buttons[_activeCountButton].transform.position, _offset);
            }

            yield return null;

            if ((_activeCountButton + count) >= 0 && (_activeCountButton + count) < _buttons.Count)
            {
                _activeCountButton += count;

                if (_useDetermination)
                    _determination.SetPosition(_buttons[_activeCountButton].transform.position, _offset);

                if (_useColor)
                {
                    foreach (var button in _buttons)
                    {
                        button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                    }

                    _buttons[_activeCountButton].GetComponentInChildren<TextMeshProUGUI>().color = _enableColor;
                }
            }
            else
            {
                if (count == 1)
                {
                    _eventLimitRight?.Invoke();

                    if (_eventLimitRight.GetPersistentEventCount() != 0)
                    {
                        if (_useColor)
                        {
                            foreach (var button in _buttons)
                            {
                                button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                            }
                        }                   
                    }
                }
                else if (count == -1)
                {
                    _eventLimitLeft?.Invoke();

                    if (_eventLimitLeft.GetPersistentEventCount() != 0)
                    {
                        if (_useColor)
                        {
                            foreach (var button in _buttons)
                            {
                                button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                            }
                        }
                    }
                }
                else if (count > 1)
                {
                    _eventLimitDown?.Invoke();

                    if (_eventLimitDown.GetPersistentEventCount() != 0)
                    {
                        if (_useColor)
                        {
                            foreach (var button in _buttons)
                            {
                                button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                            }
                        }
                    }
                }
                else if (count < -1)
                {
                    _eventLimitUp?.Invoke();

                    if (_eventLimitUp.GetPersistentEventCount() != 0)
                    {
                        if (_useColor)
                        {
                            foreach (var button in _buttons)
                            {
                                button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                            }
                        }
                    }
                }
            }
        }
    }

    private IEnumerator UseButton()
    {
        if (_buttons[_activeCountButton].eventCheck)
        {
            yield return null;
            _buttons[_activeCountButton].UseIvent(gameObject.GetComponent<ButtonManager>());

            if (_transition)
            {
                SetIsActive(false);

                if (_useDetermination)
                {
                    if (_determination)
                        Destroy(_determination.gameObject);
                }

                if (_useColor)
                {
                    foreach (var button in _buttons)
                    {
                        button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                    }
                }
            }
        }
     }

    private IEnumerator Back()
    {
        if (_event.GetPersistentEventCount() != 0 && _previousButtonManager)
        {
            SetIsActive(false);
            yield return null;

            if (_previousButtonManager)
            {
                _previousButtonManager.SetIsActive(true);
            }

            if (_useDetermination)
            {
                if (_determination)
                    Destroy(_determination.gameObject);
            }

            if (_useColor)
            {
                foreach (var button in _buttons)
                {
                    button.GetComponentInChildren<TextMeshProUGUI>().color = _disableColor;
                }
            }

            _event.Invoke();
        }
    }
}