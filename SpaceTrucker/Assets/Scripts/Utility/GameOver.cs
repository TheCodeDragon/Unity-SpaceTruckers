using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : Menu {
    //The game over manager//
    //Inherits from the menu script, since that has the fucntions it needs to run

    public GameObject EnemyBase;
    public GameObject Player;

    void Update()
    {
        //Win condition
        if(EnemyBase == null)
        {
            LevelLoader("Win");
        }
        //Lose Condition
        else if(Player == null)
        {
            LevelLoader("Lose");
        }
    }
}
