using Buttons;
using UnityEngine;
using Zenject;

namespace Code
{
    public class PreparationBattleState : BattleState
    {
        [SerializeField] 
        private float _speed = 10;

        [SerializeField] 
        private SpriteRenderer _blackBackground;

        [SerializeField] 
        private Transform _targetPosition;

        private Determination _determination;
        private float _alpha;

        [Inject]
        public void Construct(Determination determination)
        {
            _determination = determination;
        }

        public override void Enter()
        {
            gameObject.SetActive(true);
            _blackBackground.gameObject.SetActive(true);

            if (!_determination.gameObject.activeSelf)
                _determination.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            _blackBackground.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        public override void Tick()
        {
            var determinationPosition = _determination.transform.position;
            var buttonPosition = _targetPosition.position;
            
            if (determinationPosition != buttonPosition)
                _determination.transform.position = Vector3.MoveTowards(determinationPosition, buttonPosition, _speed * Time.deltaTime);
            else             if (_alpha < 1)
            {
                _alpha += Time.deltaTime;
                _blackBackground.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, Mathf.Lerp(0, 1, _alpha)));
            }
            else
                Exit();
        }
    }
}