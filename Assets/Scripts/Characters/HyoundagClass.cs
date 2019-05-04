using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyoundagClass : BaseCharClass
{
    public HyoundagClass()
    {
        CharClassName = "Hyoundag";
        CharClassDesc = "Enemy Doge";
        HealthPoints = 10;
        MemePoints = 5;
        Moveset = new int[] { 0 };
    }
}
