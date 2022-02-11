using UnityEngine;

namespace Player
{
    public class PlayerPause : MonoBehaviour
    {
        public void OnPause()
        {
            if (GetComponentInParent<PlayerMovement>()) GetComponentInParent<PlayerMovement>().enabled = false;
            if (GetComponentInParent<OpenInventory>()) GetComponentInParent<OpenInventory>().enabled = false;
            if (GetComponentInChildren<PlayerInteraction>()) GetComponentInChildren<PlayerInteraction>().enabled = false;
        }

        public void OffPause()
        {
            if (GetComponentInParent<PlayerMovement>()) GetComponentInParent<PlayerMovement>().enabled = true;
            if (GetComponentInParent<OpenInventory>()) GetComponentInParent<OpenInventory>().enabled = true;
            if (GetComponentInChildren<PlayerInteraction>()) GetComponentInChildren<PlayerInteraction>().enabled = true;
        }
    }
}