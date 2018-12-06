using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass : BaseCharClass
{
    //By default, in case of null data, the enemy is Wojak
    public BaseEnemyClass()
    {
        CharClassName = "Wojak the Feels Guy";
        CharClassDesc = "Wojak?";
        HealthPoints = 10;
        MemePoints = 10;
    }
}   
