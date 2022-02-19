using System.Collections.Generic;
using Text;
using UnityEngine;

namespace Buttons
{
    public class ButtonUsingItem : ButtonBase
    {
        private ItemBase _item;
        private Cell _cell;
        private List<string> _texts;

        [SerializeField] private DialogueWindow dialogueWindow;

        public void Initialized(Cell cell)
        {
            _cell = cell;
            _item = cell.item;
        }

        public void UseItem()
        {
            _texts[0] = $"*Вы использовали {_item.itemName}\n*Вы восстановили {_item.cost} хп";
            dialogueWindow.gameObject.SetActive(true);
            //dialogueWindow.Construct(_texts);
            PlayerPrefs.DeleteKey($"Item{_cell.number}");
        }

        public void InfoItem()
        {
            _texts[0] = $"*{_item.itemName}-восстанавливает {_item.cost} хп\n*{_item.description}";
            dialogueWindow.gameObject.SetActive(true);
            Debug.Log(dialogueWindow);
            //dialogueWindow.Construct(_texts);
        }

        public void DropItem()
        {
            _texts[0] = $"*Вы выбросили  {_item.itemName}";
            dialogueWindow.gameObject.SetActive(true);
            //dialogueWindow.Construct(_texts);
            PlayerPrefs.DeleteKey($"Item{_cell.number}");
        }
    }
}
