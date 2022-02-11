using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private readonly int OtherState = Animator.StringToHash("OtherState");
        private readonly int State = Animator.StringToHash("State");

        public void PlayLay()
        {
            _animator.SetBool(OtherState, true);
            _animator.SetFloat(State, 0);
        }

        public void PlayNotLay()
        {
            _animator.SetBool(OtherState, false);
        }

        public void PlayMove(float speed)
        {
            _animator.SetFloat("Speed", speed);
        }

        public void LookAway(float horizontal, float vertical)
        {
            _animator.SetFloat("Horizontal", horizontal);
            _animator.SetFloat("Vertical", vertical);
        }
    }
}
