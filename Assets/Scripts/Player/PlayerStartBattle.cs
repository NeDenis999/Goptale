using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerStartBattle : MonoBehaviour
    {
        [SerializeField]
        private Danger _danger;
        
        [SerializeField]
        private GameObject _background;
        
        [SerializeField]
        private GameObject _heart;

        public void ShowDanger() => 
            _danger.Show();
        
        public void HideDanger() => 
            _danger.Hide();

        public IEnumerable<WaitForSeconds> StartBattle()
        {
            ShowDanger();
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = int.MaxValue - 1;
            HideDanger();
            _background.SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                _heart.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                _heart.SetActive(false);
                yield return new WaitForSeconds(0.15f);
            }

            _heart.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("BattleScene");
        }
    }
}