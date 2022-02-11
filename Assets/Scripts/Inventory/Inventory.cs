using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _windowIncentory;
    [SerializeField] private GameObject _noItems;

    private List<Cell> _cells = new List<Cell>();

    private void Awake()
    {
        PlayerPrefs.SetInt("Item0", 0);
        //PlayerPrefs.DeleteAll();
    }

    private void OnEnable()
    {
        Initialized();
    }

    private void Initialized()
    {
        _cells = new List<Cell>();

        int startCount = 0;

        foreach (Cell cell in GetComponentsInChildren<Cell>())
        {
            _cells.Add(cell);
            cell.Initialized(startCount);
            startCount++;
        }

        bool isItem = false;

        for (int number = 0; number < 8; number++)
        {
            if (PlayerPrefs.HasKey($"Item{number}"))
            {
                isItem = true;
            }
        }

        if (!isItem)
        {
            _noItems.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {

        }
    }
}