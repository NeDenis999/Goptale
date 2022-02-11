using System.Collections;
using UnityEngine;

public class PlayerShaking : MonoBehaviour
{
    [SerializeField] private float _distance = 1.5f;
    [SerializeField, Range(1f, 0.001f)] private float _moveStep = 0.1f;
    [SerializeField, Range(1f, 0.001f)] private float _timeStep = 0.1f;

    private Transform _transform;
    private Vector2 _nextPosition;
    private Vector2 _startPosition;
    private Vector2 _currentPosition;

    private void Start()
    {
        _transform = transform;
        _startPosition = _transform.localPosition;
        _nextPosition = _startPosition;
        _currentPosition = _startPosition;
    }

    public IEnumerator Shake()
    {
        for (int i = 0; i < 10; i++)
        {
            _nextPosition = _startPosition + new Vector2(0, Random.Range(-_distance, _distance)) * transform.localScale;

            _currentPosition = _transform.position;
            yield return new WaitForSeconds(0.01f);

            float percent = 0;

            while (_nextPosition != (Vector2)_transform.localPosition)
            {
                MoveToShake(_currentPosition, _nextPosition, percent);
                percent += _moveStep;
                yield return new WaitForSeconds(_timeStep);
            }
        }
    }

    private void MoveToShake(Vector2 currentPosition, Vector2 nextPosition, float percent) => 
        _transform.localPosition = Vector2.Lerp(currentPosition, nextPosition, percent);
}
