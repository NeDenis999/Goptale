using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    [SerializeField] private ItemManager _itemManager;

    private TextMeshProUGUI displayText;

    private ItemBase _item;
    public ItemBase item => _item;

    private int _number = 0;
    public int number => _number;

    private void Awake()
    {
        displayText = GetComponent<TextMeshProUGUI>();
    }

    public void Initialized(int number)
    {
        _item = PlayerPrefs.HasKey($"Item{number}") ? _itemManager.items[PlayerPrefs.GetInt($"Item{number}")] : null;

        _number = number;

        if (_item != null)
        {
            displayText.text = _item.itemName;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
