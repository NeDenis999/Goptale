using System;
using System.Collections;
using Dialogues;
using Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Text
{
    public class DialogueWindow : MonoBehaviour
    {
        private const string NotTextMessange = "Добавь сообщение";
        private const string Submit = "Submit";
        private const string Cancel = "Cancel";

        [SerializeField] 
        private TextMeshProUGUI _textMeshPro;

        [SerializeField] 
        private AudioSource _musicPlayer;
        
        private Dialogue _dialogue;
        private int _numberNodes = 0;
        private int _lengthText = 0;
        private PlayerPause _playerPause;

        public event Action EventClosing;
        
        public void Construct(PlayerPause playerPause)
        {
            _playerPause = playerPause;
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
            if (Input.GetButtonDown(Cancel))
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
                _musicPlayer.clip = NodeSoundPrint();

                while (_lengthText <= TextLength())
                {
                    _textMeshPro.maxVisibleCharacters = _lengthText;
                    _lengthText++;
                    
                    if (_musicPlayer.clip)
                        _musicPlayer.Play();
                    
                    yield return new WaitForSeconds(_dialogue.Nodes[_numberNodes].SpeedRecruiting);
                }

                yield return new WaitUntil(() => 
                    Input.GetButtonDown(Submit));
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

        private AudioClip NodeSoundPrint() => 
            _dialogue.Nodes[_numberNodes].soundPrint;
    }
}
