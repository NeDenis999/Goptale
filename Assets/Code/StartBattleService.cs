using System.Collections;
using Infrastructure.Services;
using OtherLogic;
using Player;
using UnityEngine;
using Zenject;

namespace Code
{
    public class StartBattleService : MonoBehaviour
    {
        [SerializeField]
        private Danger _dangerPrefab;
        
        [SerializeField]
        private GameObject _backgroundPrefab;

        private PlayerPause _playerPause;
        private CameraMovement _cameraMovement;
        private ITransitionLevelService _transitionLevelService;

        private Danger _danger;
        private GameObject _background;
        private Determination _determination;

        private Vector3 _cameraPosition;

        [Inject]
        public void Construct(PlayerPause playerPause, CameraMovement cameraMovement, ITransitionLevelService transitionLevelService, Determination determination)
        {
            _playerPause = playerPause;
            _cameraMovement = cameraMovement;
            _transitionLevelService = transitionLevelService;
            _determination = determination;

            InstanceObject();
        }

        public void StartBattle() => 
            StartCoroutine(WaitStartBattle());

        private void ChangeDeterminationPosition()
        {
            _determination.transform.position -= _cameraPosition;
        }

        private IEnumerator WaitStartBattle()
        {
            _playerPause.enabled = false;
            _determination.transform.position = _playerPause.transform.position + new Vector3(0, 0.4f, 0);
            ShowDanger();
            yield return new WaitForSeconds(1);
            HideDanger();
            _playerPause.GetComponent<SpriteRenderer>().sortingOrder = 10;
            _background.SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                _determination.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                _determination.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.15f);
            }

            _determination.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            _playerPause.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _cameraPosition = _cameraMovement.transform.position;
            _transitionLevelService.TransitLevel("BattleScene", ChangeDeterminationPosition);
        }

        private void InstanceObject()
        {
            _danger = Instantiate<Danger>(_dangerPrefab, _playerPause.transform);
            _background = Instantiate<GameObject>(_backgroundPrefab, _cameraMovement.transform);

            _danger.gameObject.SetActive(false);
            _background.SetActive(false);
            _determination.gameObject.SetActive(false);
        }

        private void ShowDanger() => 
            _danger.Show();

        private void HideDanger() => 
            _danger.Hide();
    }
}
