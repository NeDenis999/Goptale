using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1f;

    [SerializeField] private float _maxDown = -100f;
    [SerializeField] private float _maxLeft = -100f;
    [SerializeField] private float _maxRight = 100f;
    [SerializeField] private float _maxUp = 100f;

    private Vector2 _realTarget;

    private void FixedUpdate()
    {
        CheakPosition();
        Movement();
    }

    private void Start()
    {
        /*var screen = MainCamera;

        _maxDown = _maxDown / 1080 * screen.height;
        _maxLeft = _maxLeft / 1920 * screen.width;
        _maxRight = _maxRight / 1920 * screen.width;
        _maxUp = _maxUp / 1080 * screen.height;*/
    }

    public void SetBoundaries(float maxDown, float maxLeft, float maxRight, float maxUp)
    {
        _maxDown = maxDown;
        _maxLeft = maxLeft;
        _maxRight = maxRight;
        _maxUp = maxUp;
    }

    public void SetBoundaries(float maxDown, float maxLeft, float maxRight, float maxUp, float speed)
    {
        _maxDown = maxDown;
        _maxLeft = maxLeft;
        _maxRight = maxRight;
        _maxUp = maxUp;

        _speed = speed;
    }

    private void CheakPosition()
    {
        _realTarget = _target.position;

        if (_target.position.x < _maxLeft)
        {
            _realTarget = new Vector2(_maxLeft, _realTarget.y);
        }

        if (_target.position.x > _maxRight)
        {
            _realTarget = new Vector2(_maxRight, _realTarget.y);
        }

        if (_target.position.y < _maxDown)
        {
            _realTarget = new Vector2(_realTarget.x, _maxDown);
        }

        if (_target.position.y > _maxUp)
        {
            _realTarget = new Vector2(_realTarget.x, _maxUp);
        }
    }

    private void Movement()
    {
        transform.position = Vector2.Lerp(transform.position, _realTarget, _speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
