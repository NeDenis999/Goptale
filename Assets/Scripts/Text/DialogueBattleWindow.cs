using System;
using System.Collections;
using Dialogues;
using Player;
using TMPro;
using UnityEngine;

namespace Text
{
    public class DialogueBattleWindow : MonoBehaviour
    {
        private const string NotTextMessange = "Добавь сообщение";
        private const string Submit = "Submit";
        private const string Cancel = "Cancel";

        [SerializeField] 
        private TextMeshProUGUI _textMeshPro;

        private DialogueOneMessage _dialogue;
        private int _lengthText = 0;

        private void Update()
        {
            if (Input.GetButtonDown(Cancel))
                ShowAllText();
        }

        public void Show(DialogueOneMessage dialogue)
        {
            _dialogue = dialogue;
            _lengthText = 0;

            gameObject.SetActive(true);
            StartCoroutine(ShowText());
        }
        
        public void ShowTextMeshPro()
        {
            _textMeshPro.gameObject.SetActive(true);
            _lengthText = 0;
            StartCoroutine(ShowText());
        }

        public void HideTextMeshPro() => 
            _textMeshPro.gameObject.SetActive(false);

        private void ShowAllText() => 
            _lengthText = TextLength();

        private IEnumerator ShowText()
        {
            _lengthText = 0;
            _textMeshPro.text = CurrentText();

            while (_lengthText <= TextLength())
            {
                _textMeshPro.maxVisibleCharacters = _lengthText;
                _lengthText++;

                yield return new WaitForSeconds(_dialogue.Node.SpeedRecruiting);
            }
        }

        private void Hide() => 
            gameObject.SetActive(false);

        private int TextLength() => 
            CurrentText().Length;

        private string CurrentText() => 
            "*" + _dialogue.Node.Text;
    }
}