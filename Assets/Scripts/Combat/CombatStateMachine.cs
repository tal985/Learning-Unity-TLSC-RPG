using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStateMachine : MonoBehaviour
{
    public static BattleStates currentState;
    public GameObject enemy;
    private bool mainCombatMenu = true, hasClicked = false;
    private int difference = 0, playerAtk = -1, enemyAtk = -1;
    private Slider pSlider, eSlider;
    private BaseEnemy newEnemy = new BaseEnemy();
    //private string[] enemyNames = new string[] { "Wojack Horseman", "Wojak the Feels Guy", "Anon", "Definite Not Pepe" };

    public enum BattleStates
    {
        START,
        PLAYERCHOICE,
        ENEMYCHOICE,
        CALCDMG,
        LOSE,
        WIN
    }

    // Use this for initialization
    void Start ()
    {
        currentState = BattleStates.START;
        RenderEnemy();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(currentState);
	    switch (currentState)
        {
            //Startup battle functions
            case (BattleStates.START):
            {
                //Remove newgame line later
                GameInfo.NewGame();
                CreateNewEnemy();
                currentState = BattleStates.PLAYERCHOICE;
                break;
            }
            //Game logic pertaining to player choices
            case (BattleStates.PLAYERCHOICE):
            {
                //Cost calculation
                if (difference < 0 && hasClicked)
                {
                    Debug.Log("Not enough MP! Please select another option.");
                    hasClicked = false;
                    difference = 0;
                    playerAtk = -1;
                }
                else if (difference >= 0 && hasClicked)
                {
                    GameInfo.Cmp = difference;
                    //Debug.Log("Going to next phase and resetting difference! Player MP difference: " + difference);
                    //Debug.Log("\nCurrent MP: " + GameInfo.Cmp);
                    difference = 0;
                    hasClicked = false;
                    mainCombatMenu = true;
                    currentState = BattleStates.ENEMYCHOICE;
                }
                break;
            }
            //Game logic pertaining to enemy choices
            case (BattleStates.ENEMYCHOICE):
            {
                //Insert enemy choice battle functions here
                //TODO: Add rng attack and cost checking for enemy
                enemyAtk = 0;
                currentState = BattleStates.CALCDMG;
                break;
            }
            //Game logic pertaining to damage calculations; player always gets priority
            case (BattleStates.CALCDMG):
            {
                //Player always gets priority
                //Debug.Log(GameInfo.Chp);
                //If self-cast, subtract the negative damage from oneself
                if (GameInfo.abilityDict[playerAtk].SelfCast)
                    GameInfo.Chp -= GameInfo.abilityDict[playerAtk].AbilityDamage;
                else
                    newEnemy.Chp -= GameInfo.abilityDict[playerAtk].AbilityDamage;

                Debug.Log(GameInfo.Chp);

                if (GameInfo.abilityDict[enemyAtk].SelfCast)
                    newEnemy.Chp -= GameInfo.abilityDict[enemyAtk].AbilityDamage;
                else
                    GameInfo.Chp -= GameInfo.abilityDict[enemyAtk].AbilityDamage;

                
                if (newEnemy.Chp <= 0)
                    currentState = BattleStates.WIN;
                else if (GameInfo.Chp <= 0)
                    currentState = BattleStates.LOSE;
                else
                    currentState = BattleStates.PLAYERCHOICE;
                break;
            }
            case (BattleStates.LOSE):
            {
                //Insert lose functions here
                //Debug.Log("Game Over!");
                break;
            }
            case (BattleStates.WIN):
            {
                //Insert win battle functions here
                //Debug.Log("You win! Go back to overworld.");
                break;
            }
        }
        if (GameInfo.Chp > 0 && newEnemy.Chp > 0)
        {
            //GUI.TextField
        }

    }

    void OnGUI()
    {
        if (currentState == BattleStates.PLAYERCHOICE)
        {
            if(mainCombatMenu)
            {
                if (GUI.Button(new Rect(50, Screen.height - 100, 100, 30), "Attack"))
                    mainCombatMenu = false;
            }
            else
            {
                if (GUI.Button(new Rect(50, Screen.height - 150, 100, 30), "Back"))
                    mainCombatMenu = true;

                //TODO: set playerAtk and enemyAtk to the values at the index instead; manually setting atm
                //Ability 0 should always be the basic attack, which has no cost
                else if (GUI.Button(new Rect(50, Screen.height - 100, 100, 30), GameInfo.abilityDict[0].AbilityName))
                {
                    hasClicked = true;
                    difference = 0;
                    playerAtk = 0;
                }
                else if (GUI.Button(new Rect(200, Screen.height - 100, 100, 30), GameInfo.abilityDict[1].AbilityName))
                {
                    hasClicked = true;
                    difference = GameInfo.Cmp - GameInfo.abilityDict[1].AbilityCost;
                    playerAtk = 1;
                }
                else if (GUI.Button(new Rect(50, Screen.height - 50, 100, 30), GameInfo.abilityDict[2].AbilityName))
                {
                    hasClicked = true;
                    difference = GameInfo.Cmp - GameInfo.abilityDict[2].AbilityCost;
                    playerAtk = 2;
                }
                else if (GUI.Button(new Rect(200, Screen.height - 50, 100, 30), GameInfo.abilityDict[3].AbilityName))
                {
                    hasClicked = true;
                    difference = GameInfo.Cmp - GameInfo.abilityDict[3].AbilityCost;
                    playerAtk = 3;
                }
            }
        }
    }

    //Create enemy
    private void CreateNewEnemy()
    {
        newEnemy.PlayerClass = new BaseEnemyClass();
        newEnemy.Level = Random.Range(GameInfo.PlayerLevel - 2, GameInfo.PlayerLevel + 3);
        newEnemy.PlayerClass.CharClassName = GameInfo.currentEnemy;
        Debug.Log(newEnemy.PlayerClass.CharClassName);
        newEnemy.PlayerClass.HealthPoints = Random.Range(0, 3) + 15;
        newEnemy.Chp = newEnemy.PlayerClass.HealthPoints;
        newEnemy.PlayerClass.MemePoints = Random.Range(0, 3) + 15;
        newEnemy.Cmp = newEnemy.PlayerClass.MemePoints;
        newEnemy.MovesetIDs = new int[] { 0 };
    }
    
    //Render enemy
    private void RenderEnemy()
    {
        if (GameInfo.currentEnemy != null)
            enemy.GetComponent<Animator>().Play(GameInfo.currentEnemy);
        else
            enemy.GetComponent<Animator>().Play("PepeDefault"); 
        /*
        switch (GameInfo.currentEnemy)
        {
            case ("Hyoundag"):
            {
                temp.Play("Hyoundag");
                break;
            }
            default:
            {
                temp.Play("PepeDefault");
                break;
            }
        }
        */
    }
}
