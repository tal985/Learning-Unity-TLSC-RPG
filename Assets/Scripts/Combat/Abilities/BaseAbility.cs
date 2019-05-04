//Parent class for all abilities
//TO DO: Make damage be used as the healing amount for healing abilities
//using UnityEngine;
[System.Serializable]

public class BaseAbility
{
    //The cost and damage here supposed to just store base damages. 
    //TODO: Add damage modifiers elsewhere for RNG damage
    protected string abilityName, abilityDesc;
    protected int abilityCost, abilityDamage, abilityHeal;

    public string AbilityName { get; set; }
    public string AbilityDesc { get; set; }
    public int AbilityCost { get; set; }
    public int AbilityDamage { get; set; }
    public int AbilityHeal { get; set; }
}
