using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterClass : BaseCharClass
{
    public ChapterClass()
    {
        CharClassName = "Mr. Chapter";
        CharClassDesc = "The wisest of the wise.";
        HealthPoints = 30;
        MemePoints = 20;
        //Add 5 - 9 later
        Moveset = new int[] { 0, 1, 2, 3, 4 };
    }
}
