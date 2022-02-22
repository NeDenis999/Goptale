using System;
using Screens;
using UnityEngine;
using Zenject;

namespace Buttons
{
    public class ButtonChouseEnemy : Button
    {
        [SerializeField]
        private Transform _target;

        [SerializeField] 
        private HitWindow _hitWindow;
        
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

        public override void Press()
        {
            _hitWindow.Show();
        }
    }
}