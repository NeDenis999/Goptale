using UnityEngine;

namespace Player
{
    public class Danger : MonoBehaviour
    {
        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}