using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class MettatonShowText : MonoBehaviour, IShowText
{
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Initialization(TestText textMeshPro)
    {
        throw new System.NotImplementedException();
    }

    public async void ShowText(string text)
    {
        _textMeshPro.maxVisibleCharacters = 0;

        while (_textMeshPro.maxVisibleCharacters <= text.Length)
        {
            await Task.Delay(500);
            _textMeshPro.maxVisibleCharacters += 5;
        }
    }
}
