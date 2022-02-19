using UnityEngine;
using UnityEngine.Events;

namespace Buttons
{
    public class ButtonBase : MonoBehaviour
    {
        [SerializeField] protected UnityEvent _event;
        [SerializeField] private ButtonManager _nextButtonManager;

        public bool eventCheck => _event.GetPersistentEventCount() != 0;
        public bool nextButtonManagerCheck => _nextButtonManager;

        public virtual void UseIvent(ButtonManager previousButtonManager = null)
        {
            _event.Invoke();

            if (_nextButtonManager && _nextButtonManager.gameObject.activeSelf)
            {
                _nextButtonManager.SetIsActive(true);
                _nextButtonManager.SetPreviousButtonManager(previousButtonManager);
            }
        }
    }
}