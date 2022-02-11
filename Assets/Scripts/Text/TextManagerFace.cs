using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextManagerFace : MonoBehaviour
{
    //[SerializeField] private List<int> _feelings;
    //[SerializeField] private List<string> _texts = new List<string>();

    [SerializeField] private List<Replic> _replics = new List<Replic>();
    [SerializeField] private float _speedRecruiting = 0.05f;
    [SerializeField] private int _countSymbol = 1;
    [SerializeField] private UnityEvent _eventClosing;

    private TextMeshProUGUI _textMeshPro;
    private Animator _animator;
    private int _numberText = 0;
    private int _lengthText = 0;

    private void Awake()
    {
        if (_replics.Count == 0)
        {
            _replics.Add(new Replic());
            _replics[0].Text = "не забудь добавить текст";
        }

        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _numberText = 0;
        _lengthText = 0;

        StartCoroutine(ShowText());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            ShowAllText();
    }

    public void Initialized(List<Replic> replics)
    {
        _replics = replics;
    }

    private void CloseWindow()
    {
        _eventClosing.Invoke();
        gameObject.SetActive(false);
    }

    public void ShowAllText()
    {
        _lengthText = _replics[_numberText].Text.Length;
    }

    public IEnumerator ShowText()
    {
        _lengthText = 0;
        _textMeshPro.text = _replics[_numberText].Text;

        _animator.SetInteger("Feeling", 1);

        while (_lengthText <= _replics[_numberText].Text.Length)
        {
            _textMeshPro.maxVisibleCharacters = _lengthText;
            _lengthText += _countSymbol;

            yield return new WaitForSeconds(_speedRecruiting);
        }

        if (_replics.Count <= _numberText)
        {
            _animator.SetInteger("Feeling", _replics[_numberText].Feeling);
        }
        else
        {
            _animator.SetInteger("Feeling", 0);
        }

        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));

        if (_numberText == _replics.Count - 1)
        {
            CloseWindow();
        }
        else
        {
            _numberText++;
            StartCoroutine(ShowText());
        }
    }
}

[System.Serializable]
public class Replic
{
    public string Text;
    public int Feeling;
}
