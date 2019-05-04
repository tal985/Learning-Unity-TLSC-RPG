using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy
{
    public string Name;
    public int[] MovesetIDs;
    public int Level, Chp, Cmp, Thp, Tmp;

    public BaseEnemy(BaseCharClass newEnemy)
    {
        Level = 1;
        Thp = newEnemy.HealthPoints;
        Chp = Thp;
        Tmp = newEnemy.MemePoints;
        Cmp = Tmp;
        Name = newEnemy.CharClassName;
        MovesetIDs = newEnemy.Moveset;
    }
}
