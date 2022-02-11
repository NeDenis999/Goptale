using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delayTime = 0.5f;
    [SerializeField] private UnityEvent _event;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_delayTime);
        _event.Invoke();
    }
}