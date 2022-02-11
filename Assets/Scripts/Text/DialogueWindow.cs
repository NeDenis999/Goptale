using System;
using System.Collections;
using Dialogues;
using Player;
using TMPro;
using UnityEngine;

namespace Text
{
    public class DialogueWindow : MonoBehaviour
    {
        private const string NotTextMessange = "Добавь сообщение";

        [SerializeField] 
        private TextMeshProUGUI _textMeshPro;
        
        private Dialogue _dialogue;
        private int _numberNodes = 0;
        private int _lengthText = 0;
        private PlayerPause _playerPause;

        public event Action EventClosing;

        public void Construct(PlayerPause playerPause)
        {
            _playerPause = playerPause;
            Hide();
        }
        
        public void Show(Dialogue dialogue)
        {
            _dialogue = dialogue;
            _numberNodes = 0;
            _lengthText = 0;

            if (_dialogue.Nodes.Count == 0) 
                _dialogue.Nodes.Add(new Node(NotTextMessange));

            gameObject.SetActive(true);
            StartCoroutine(ShowText());
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
                ShowAllText();
        }

        private void ShowAllText() => 
            _lengthText = TextLength();

        private IEnumerator ShowText()
        {
            for (_numberNodes = 0; _numberNodes < _dialogue.Nodes.Count; _numberNodes++)
            {
                _lengthText = 0;
                _textMeshPro.text = CurrentText();

                while (_lengthText <= TextLength())
                {
                    _textMeshPro.maxVisibleCharacters = _lengthText;
                    _lengthText++;

                    yield return new WaitForSeconds(_dialogue.Nodes[_numberNodes].SpeedRecruiting);
                }

                yield return new WaitUntil(() => 
                    Input.GetButtonDown("Submit"));
            }
            
            _playerPause.OffPause();
            Hide();
        }

        private void Hide()
        {
            EventClosing?.Invoke();
            gameObject.SetActive(false);
        }

        private int TextLength() => 
            CurrentText().Length;

        private string CurrentText() => 
            _dialogue.Nodes[_numberNodes].Text;

        private bool NodeEnd() => 
            (_numberNodes >= _dialogue.Nodes.Count);
    }
}
