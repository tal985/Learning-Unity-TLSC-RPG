using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepeClass : BaseCharClass
{
    public PepeClass()
    {
        CharClassName = "Pepe the Frog";
        CharClassDesc = "The smuggest of the smug.";
        HealthPoints = 20;
        MemePoints = 20;
        Moveset = new int[] { 0 };
    }
}
