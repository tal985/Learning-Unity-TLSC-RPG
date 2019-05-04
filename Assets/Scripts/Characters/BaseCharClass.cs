using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharClass
{
    protected string charClassName, charClassDesc;
    protected int healthPoints, memePoints;
    protected int[] moveset;

    public string CharClassName { get; set; }
    public string CharClassDesc { get; set; }
    public int HealthPoints { get; set; }
    public int MemePoints { get; set; }
    public int[] Moveset { get; set; }
}
