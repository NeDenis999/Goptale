using System;
using UnityEngine;
using UnityEngine.Events;

namespace OtherLogic
{
    public class Interplay : InterplayBase
    {
        [SerializeField] 
        public event Action _event;

        public override void Interaction() => 
            _event?.Invoke();
    }
}
