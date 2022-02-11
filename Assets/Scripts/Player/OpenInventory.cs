using UnityEngine;

namespace Player
{
    public class OpenInventory : MonoBehaviour
    {
        [SerializeField] 
        private InventoryScreen _inventory;

        [SerializeField] 
        private PlayerPause _pause;

        private void Update()
        {
            if (Input.GetButtonDown("OpenInventory") && _inventory) 
                ShowInventory();
        }

        private void ShowInventory()
        {
            _inventory.Show();
            _pause.OnPause();
        }
    }
}
