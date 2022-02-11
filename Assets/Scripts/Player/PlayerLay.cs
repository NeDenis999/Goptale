using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerAnimator), typeof(PlayerMovement), typeof(PlayerShaking))]
    public class PlayerLay : MonoBehaviour
    {
        private const float WaitToGetUp = 0.5f;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        private readonly WaitForSeconds _waitYieldInstruction = new WaitForSeconds(WaitToGetUp);

        [SerializeField] 
        private PlayerAnimator _animator;
        
        [SerializeField]
        private PlayerMovement _movement;
        
        [SerializeField]
        private PlayerShaking _shaking;

        private int _attemptsClimb = 0;

        private void OnEnable()
        {
            _animator.PlayLay();
            _shaking.enabled = true;
            _movement.enabled = false;

            StartCoroutine(TryToGetUp());
        }

        private IEnumerator TryToGetUp()
        {
            while (_attemptsClimb < 4)
            {
                _attemptsClimb++;
                yield return new WaitUntil(() => 
                    Input.GetButton(Horizontal)
                    | Input.GetButton(Vertical));

                yield return _shaking.Shake();
                yield return _waitYieldInstruction;
            }

            GetUp();
        }

        private void GetUp()
        {
            _animator.PlayNotLay();
            _shaking.enabled = false;
            _movement.enabled = true;
            enabled = false;
        }
    }
}
