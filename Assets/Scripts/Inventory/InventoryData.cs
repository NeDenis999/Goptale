using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory", order = 351)]
public class InventoryData : ScriptableObject
{
    public ItemBase[] items;
}
