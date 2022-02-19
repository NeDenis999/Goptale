using UnityEngine;
using Zenject;

namespace Buttons
{
    public class ButtonChouseAction : Button
    {
        [SerializeField]
        private Transform _target;
        
        private Determination _determination;
        
        [Inject]
        public void Construct(Determination determination)
        {
            _determination = determination;
        }
        
        public override void Selected()
        {
            _determination.transform.position = _target.position;
        }
    }
}