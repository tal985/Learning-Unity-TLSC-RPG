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
        PlayerClass = new ChapterClass();   
        PlayerLevel = 1;
        PlayerName = PlayerClass.CharClassName;
        Thp = PlayerClass.HealthPoints;
        Tmp = PlayerClass.MemePoints;
        Chp = Thp;
        Cmp = Tmp;
        MovesetIDs = PlayerClass.Moveset;
        /*
        Debug.Log("Game Info Name: " + PlayerName);
        Debug.Log("Game Info Level: " + PlayerLevel);
        Debug.Log("Game Info HP: " + Php);
        Debug.Log("Game Info MP: " + Pmp);
        Debug.Log("Game Info Moveset IDs: " + string.Join(", ", Array.ConvertAll(MovesetIDs, element => element.ToString())));
        */
    }

    //Initialize dictionary with abilities
    // 0 - 4 are MC's regular abilities
    // 5 - 9 are MC's super saiyan abilities
    // 10 - ???
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
                AbilityHeal = 0
            });

        //Block
        abilityDict.Add(1,
            new BaseAbility
            {
                AbilityName = "Block",
                AbilityDesc = "Negates a portion of incoming damage.",
                AbilityCost = 0,
                AbilityDamage = 0,
                AbilityHeal = 0
            });

        //Wisium Shot
        abilityDict.Add(2,
            new BaseAbility
            {
                AbilityName = "Wisium Shot",
                AbilityDesc = "A wisium projectile spell.",
                AbilityCost = 5,
                AbilityDamage = 10,
                AbilityHeal = 0
            });

        //Heal
        abilityDict.Add(3,
            new BaseAbility
            {
                AbilityName = "Heal",
                AbilityDesc = "A small heal.",
                AbilityCost = 5,
                AbilityDamage = 0,
                AbilityHeal = 5
            });

        //Ultimate (Dash Attack)
        abilityDict.Add(4,
            new BaseAbility
            {
                AbilityName = "Dash",
                AbilityDesc = "A dash attack.",
                AbilityCost = 10,
                AbilityDamage = 15,
                AbilityHeal = -5
            });

        
    }
}
