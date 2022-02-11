using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemManager", menuName = "ItemManager", order = 153)]
public class ItemManager : ScriptableObject
{
    public List<ItemBase> items;
}
