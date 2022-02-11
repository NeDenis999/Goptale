using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class StandardShowText : MonoBehaviour, IShowText
{
    private TextMeshProUGUI _textMeshPro;
    private TestText _textManager;

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialization(TestText textManager)
    {
        _textManager = textManager;
    }

    public async void ShowText(string text)
    {
        _textMeshPro.maxVisibleCharacters = 0;

        while (_textMeshPro.maxVisibleCharacters <= text.Length)
        {
            await Task.Delay(100);
            _textMeshPro.maxVisibleCharacters++;
        }

        _textManager.EndShowText();
    }
}
