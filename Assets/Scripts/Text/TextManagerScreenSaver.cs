using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Text
{
    public class TextManagerScreenSaver : TextManagerBase
    {
        [SerializeField] private AudioClip[] _audioClips;
        
        public Action EndScreenSaver;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _audioClips[0];
            StartCoroutine(CustonSpeedText());
        }

        private void CloseWindow()
        {
            EndScreenSaver?.Invoke();
            gameObject.SetActive(false);
        }

        private void CloseText()
        {
            _textMeshPro.gameObject.SetActive(false);
        }

        private IEnumerator CustonSpeedText()
        {
            _audioSource.Play();
            _lengthText = 0;

            _textMeshPro.text = _texts[_numberText];

            while (_lengthText <= _texts[_numberText].Length)
            {
                _textMeshPro.maxVisibleCharacters = _lengthText;

                if (_lengthText < _texts[_numberText].Length)
                {
                    if (_lengthText % 5 == 0 || _texts[_numberText][_lengthText] == '.')
                    {
                        if (_lengthText % 2 == 0)
                        {
                            _audioSource.clip = _audioClips[1];
                        }
                        else if (_lengthText % 3 == 0)
                        {
                            _audioSource.clip = _audioClips[2];
                        }
                        else
                        {
                            _audioSource.clip = _audioClips[3];
                        }

                        _audioSource.Play();
                    }

                }

                _lengthText += _countSymbol;

                switch (_numberText)
                {
                    case 0:
                        if (_lengthText == 13 || _lengthText == 42) _speedRecruiting = 0.6f;
                        break;

                    case 1:
                        if (_lengthText == 51) _speedRecruiting = 0.6f;
                        break;

                    case 2:
                        if (_lengthText == 50) _speedRecruiting = 0.6f;
                        break;

                    case 3:
                        _speedRecruiting = 0.08f;
                        if (_lengthText == 17 || _lengthText == 18 || _lengthText == 19) _speedRecruiting = 0.6f;
                        if (_lengthText == 20) _audioSource.Play();
                        break;

                    case 4:
                        _speedRecruiting = 0.08f;
                        _textMeshPro.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 143.3816f);
                        break;

                    case 5:
                        _textMeshPro.GetComponent<RectTransform>().sizeDelta = new Vector2(900, 143.3816f);
                        break;

                    default:
                        break;
                }

                yield return new WaitForSeconds(_speedRecruiting);
                _speedRecruiting = 0.07f;
            }

            _numberText++;
        }
    }
}