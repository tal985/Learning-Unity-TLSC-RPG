using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static Dictionary<int, BaseAbility> abilityDict = new Dictionary<int, BaseAbility>();

    //Launches before Start()
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public static string PlayerName;
    public static int PlayerLevel;
    public static BaseCharClass PlayerClass;
    public static int Thp;
    public static int Tmp;
    public static int Chp;
    public static int Cmp;
    public static int[] MovesetIDs;
    public static GameObject CurrentEnemy;
    public static Vector3 MCPos;

    //Initialize the variables for a new game
    public static void NewGame()
    {
        InitAbilityDict();
        PlayerClass = new BaseFirstClass();
        PlayerLevel = 1;
        PlayerName = PlayerClass.CharClassName;
        Thp = PlayerClass.HealthPoints;
        Tmp = PlayerClass.MemePoints;
        Chp = Thp;
        Cmp = Tmp;
        MovesetIDs = new int[] { 0, 1, 2, 3 };

        /*
        Debug.Log("Game Info Name: " + PlayerName);
        Debug.Log("Game Info Level: " + PlayerLevel);
        Debug.Log("Game Info HP: " + Php);
        Debug.Log("Game Info MP: " + Pmp);
        Debug.Log("Game Info Moveset IDs: " + string.Join(", ", Array.ConvertAll(MovesetIDs, element => element.ToString())));
        */
    }

    //Initialize dictionary with abilities
    public static void InitAbilityDict()
    {
        //Basic Attack
        abilityDict.Add(0,
            new BaseAbility
            {
                AbilityName = "Basic Attack",
                AbilityDesc = "A basic attack",
                AbilityCost = 0,
                AbilityDamage = 5,
                SelfCast = false
            });

        //Heal
        abilityDict.Add(1,
            new BaseAbility
            {
                AbilityName = "Heal I",
                AbilityDesc = "A small heal",
                AbilityCost = 5,
                AbilityDamage = -5,
                SelfCast = true
            });

        //Spell 1
        abilityDict.Add(2,
            new BaseAbility
            {
                AbilityName = "Spell",
                AbilityDesc = "A generic spell",
                AbilityCost = 5,
                AbilityDamage = 10,
                SelfCast = false
            });

        //Spell 2
        abilityDict.Add(3,
            new BaseAbility
            {
                AbilityName = "Spell II",
                AbilityDesc = "A medium spell",
                AbilityCost = 10,
                AbilityDamage = 15,
                SelfCast = false
            });
    }
}
