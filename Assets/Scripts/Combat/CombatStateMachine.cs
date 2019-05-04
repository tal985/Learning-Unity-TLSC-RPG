using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatStateMachine : MonoBehaviour
{
    public static BattleStates currentState;
    public GameObject enemy;
    private bool hasClicked = false, ssj = false;
    private int difference = 0, playerAtk = -1, enemyAtk = -1;
    private Slider pSlider, eSlider;
    private BaseEnemy newEnemy;
    public Button button_0, button_1, button_2, button_3, button_4;

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
        button_0.onClick.AddListener(() => TaskOnClick(0));
        button_1.onClick.AddListener(() => TaskOnClick(1));
        button_2.onClick.AddListener(() => TaskOnClick(2));
        button_3.onClick.AddListener(() => TaskOnClick(3));
        button_4.onClick.AddListener(() => TaskOnClick(4));
    }

    void TaskOnClick(int num)
    {
        if(!hasClicked && currentState == BattleStates.PLAYERCHOICE && !ssj)
        {
            Debug.Log("Clicked button " + num);
            hasClicked = true;
            difference = GameInfo.Cmp - GameInfo.abilityDict[num].AbilityCost;
            playerAtk = num;
        }
        //else if(!hasClicked && currentState == BattleStates.PLAYERCHOICE && ssj)
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
                if(GameInfo.abilityDict.Count == 0)
                    GameInfo.NewGame();
                CreateNewEnemy();
                RenderEnemy();
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
        

                //If self-cast, subtract the negative damage from oneself
                //if (GameInfo.abilityDict[playerAtk].SelfCast)
                //    GameInfo.Chp -= GameInfo.abilityDict[playerAtk].AbilityDamage;
                //else
                //    newEnemy.Chp -= GameInfo.abilityDict[playerAtk].AbilityDamage;
                //if (GameInfo.abilityDict[enemyAtk].SelfCast)
                //    newEnemy.Chp -= GameInfo.abilityDict[enemyAtk].AbilityDamage;
                //else
                //    GameInfo.Chp -= GameInfo.abilityDict[enemyAtk].AbilityDamage;

                //Process MC move
                BaseAbility tempAtk = GameInfo.abilityDict[playerAtk];
                GameInfo.Chp += tempAtk.AbilityHeal;
                GameInfo.Cmp -= tempAtk.AbilityCost;
                newEnemy.Chp -= tempAtk.AbilityDamage;

                //Add special code for block

                //Process enemy move
                tempAtk = GameInfo.abilityDict[enemyAtk];
                newEnemy.Chp += tempAtk.AbilityHeal;
                newEnemy.Cmp -= tempAtk.AbilityCost;
                GameInfo.Chp -= tempAtk.AbilityDamage;

                Debug.Log("MC Current HP: " + GameInfo.Chp);
                Debug.Log("MC Current MP: " + GameInfo.Cmp);
                Debug.Log("Enemy Current HP: " + newEnemy.Chp);
                Debug.Log("Enemy Current MP: " + newEnemy.Cmp);

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
                Debug.Log("Game Over!");
                break;
            }
            case (BattleStates.WIN):
            {
                //Insert win battle functions here
                Debug.Log("You win! Go back to overworld.");
                //GameObject.Find("MC_Player").GetComponent<PlayerControls>().SceneResume();
                //Destroy(GameInfo.CurrentEnemy);
                //SceneManager.UnloadSceneAsync(2);
                break;
            }
        }
    }

    void OnGUI()
    {

    }

    //Create enemy
    private void CreateNewEnemy()
    {
        //Adjust level later if game gets far enough
        if(GameInfo.CurrentEnemy == null)
        {
            newEnemy = new BaseEnemy(new PepeClass());
        }
        else
        {
            string curEnemyName = GameInfo.CurrentEnemy.GetComponent<EnemyMetaData>().MobName;
            Debug.Log(curEnemyName);
            switch(curEnemyName)
            {
                case("Hyoundag"):
                { 
                    newEnemy = new BaseEnemy(new HyoundagClass());
                    break;
                }
                default:
                {
                    newEnemy = new BaseEnemy(new PepeClass());
                    break;
                }
            }
        }
        Debug.Log("MC Current HP: " + GameInfo.Chp);
        Debug.Log("MC Current MP: " + GameInfo.Cmp);
        Debug.Log("Enemy Current HP: " + newEnemy.Chp);
        Debug.Log("Enemy Current MP: " + newEnemy.Cmp);
    }
    
    //Render enemy
    private void RenderEnemy()
    {
        Animator temp = enemy.GetComponent<Animator>();
        switch(newEnemy.Name)
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
    }
}
