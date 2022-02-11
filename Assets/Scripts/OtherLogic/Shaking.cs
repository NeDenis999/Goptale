using UnityEngine;
using Random = UnityEngine.Random;

public class Shaking : MonoBehaviour
{
    [SerializeField] private float _distance = 1.5f;

    private Transform _transform;
    private Vector2 _nextPosition;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;
    private float _currentTime;

    private void Start()
    {
        _transform = transform;
        _startPosition = _transform.localPosition;
        _nextPosition = _startPosition;
        _currentPosition = _startPosition;
    }

    private void Update()
    {
        Countdown();
    }

    public void Shake()
    {
        _nextPosition = _startPosition + new Vector2(Random.Range(-_distance, _distance), 
            Random.Range(-_distance, _distance)) * transform.localScale;

        _currentPosition = _transform.position;
        _currentTime = 0;
    }

    private void MoveToShake()
    {
        _transform.localPosition = Vector2.Lerp(_currentPosition, _nextPosition, _currentTime);
    }

    private void Countdown()
    {
        if (_currentTime <= 1) 
            MoveToShake();
        else
            return;
        
        _currentTime += Time.deltaTime * 10;
    }
}
