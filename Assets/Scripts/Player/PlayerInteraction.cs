using System.Collections.Generic;
using OtherLogic;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        private List<InterplayBase> _interplays = new List<InterplayBase>();

        public void Construct()
        {
            
        }
        
        private void Update()
        {
            if (Input.GetButtonDown("Submit"))
                SetRay(new Vector2(_animator.GetFloat("Horizontal"), _animator.GetFloat("Vertical")) / 2);  
        }

        public void SetRay(Vector2 direction)
        {
            if (Mathf.Abs(direction.x) == Mathf.Abs(direction.y))
                return;

            if (Physics2D.Raycast(transform.position, direction))
            {
                foreach (RaycastHit2D raycastHit in Physics2D.RaycastAll(transform.position, direction))
                {
                    if (raycastHit.transform.GetComponent<InterplayBase>())
                        _interplays.Add(raycastHit.transform.GetComponent<InterplayBase>());
                }

                if (_interplays.Count > 0)
                    UseInterplay();
            }
        }

        private void UseInterplay()
        {
            float minDistance = Vector2.Distance(_interplays[0].transform.position, transform.position);
            InterplayBase appointedInteraction = _interplays[0];

            foreach (InterplayBase interplay in _interplays)
            {
                if (minDistance > Vector2.Distance(interplay.transform.position, transform.position))
                {
                    minDistance = Vector2.Distance(interplay.transform.position, transform.position);
                    appointedInteraction = interplay;
                }
            }

            appointedInteraction.Interaction();

            if (GetComponentInParent<PlayerPause>())
                GetComponentInParent<PlayerPause>().OnPause();

            _interplays.Clear();
        }
    }
}
