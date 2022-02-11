using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        [SerializeField] private float _speed = 1f;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;

        private float _horizontal;
        private float _vertical;
        private Vector2 _currentLookAway = new Vector2();

        private void OnDisable() => 
            _animator.PlayMove(0);

        private void Update()
        {
            ProcessInput();
            Animation();
        }

        private void FixedUpdate() => 
            Movement();

        private void ProcessInput()
        {
            _horizontal = Input.GetAxisRaw(Horizontal);
            _vertical = Input.GetAxisRaw(Vertical);
        }

        private void Movement() => 
            _rigidbody.velocity = new Vector2(_horizontal, _vertical) * _speed;

        private void Animation()
        {
            if (_currentLookAway == new Vector2(0, 0))
            {
                if (ButtonMovePressed())
                    _currentLookAway = new Vector2(_horizontal, _vertical);
            }
            else
            {
                if (Input.GetButtonUp(Horizontal))
                    _currentLookAway.x = 0;
                else if (Input.GetButtonUp(Vertical))
                    _currentLookAway.y = 0;
            }

            if (ButtonMovePressed())
                _animator.LookAway(_currentLookAway.x, _currentLookAway.y);

            _animator.PlayMove(_rigidbody.velocity.magnitude);
        }

        private bool ButtonMovePressed() =>
            Input.GetButton(Horizontal) || Input.GetButton(Vertical);
    }
}