using UnityEngine;
using UnityEngine.Events;

namespace Buttons
{
    public class PressButtonEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent _event;
        [SerializeField] private string _nameButton = "Submit";
        [SerializeField] private CanvasGroup _canvasGroup;

        private bool _isActive
        {
            get
            {
                if (_canvasGroup != null)
                {
                    if (_canvasGroup.alpha != 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
        }

        private void Update()
        {
            if (Input.GetButtonDown(_nameButton) && _isActive)
            {
                _event.Invoke();
                _event = null;
            }
        }
    }
}
