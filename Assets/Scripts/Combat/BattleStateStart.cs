using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateStart
{
    private BaseEnemy newEnemy = new BaseEnemy();
    private string[] enemyNames = new string[] { "Wojack Horseman", "Wojak the Feels Guy", "Anon", "Definite Not Pepe" };

    public void PrepareBattle()
    {
        CreateNewEnemy();
    }

    private void CreateNewEnemy()
    {
        newEnemy.PlayerClass = new BaseEnemyClass();
        newEnemy.Level = Random.Range(GameInfo.PlayerLevel - 2, GameInfo.PlayerLevel + 3);
        newEnemy.PlayerClass.CharClassName = enemyNames[Random.Range(0, enemyNames.Length)];
        newEnemy.PlayerClass.HealthPoints = Random.Range(0, 3) + 15;
        newEnemy.PlayerClass.MemePoints = Random.Range(0, 3) + 15;
        newEnemy.MovesetIDs = new int[] { 0 };
    }

}
