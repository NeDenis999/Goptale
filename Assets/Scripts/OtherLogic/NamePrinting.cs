using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NamePrinting : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ButtonManager _buttonManager;

    private string _name;

    private void Awake()
    {
        _text.text = null;
    }

    public void Print()
    {
        _text.text += _buttonManager.ActiveButton.GetComponent<TextMeshProUGUI>().text;
    }

    public void EraseEndSymbol()
    {
        _text.text = _text.text.Substring(0, _text.text.Length - 1);
    }
}
