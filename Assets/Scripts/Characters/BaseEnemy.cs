using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy
{
    protected BaseCharClass playerClass;
    protected int level;
    protected int[] movesetIDs;
    protected int chp, cmp;

    public BaseCharClass PlayerClass { get; set; }
    public int Level { get; set; }
    public int Chp { get; set; }
    public int Cmp { get; set; }
    public int[] MovesetIDs { get; set; }
}
