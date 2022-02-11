using UnityEngine;

namespace OtherLogic
{
    public class ItemLay : Interplay
    {
        [SerializeField] private ItemBase _item;

        [SerializeField] private TextManagerBase _text;

        private void Awake()
        {
        
        }

        public override void Interaction()
        {
            //_event.Invoke();
            _text.gameObject.SetActive(true);
        }

        public void AddInventoryItem()
        {

        }
    }
}