using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : ScriptableObject
{
    public int hp = 10;
    public int recovery = 1;
    public int damage = 1;
    public string startPhrase;
    public string info;
    public Actions[] actions;
}
