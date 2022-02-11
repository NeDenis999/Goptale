using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName = "Enemy/Boss", order = 152)]
public class Boss : EnemyBase
{
    public int turnCount = 10;
    public int counterFaithful = 1;
    public bool canEscape = false;
}
