using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleController : MonoBehaviour {

    public enum BattleState
    {
        START,
        WAITING,
        PLAYER_CHOICE,
        ENEMY_CHOICE,
        DMG_PHASE,
        WIN,
        LOSE,
        EXIT
    }


    private List<Character> battleMembers;
    private BattleState currentState;
    private int c1, c2, c3, e1, e2, e3;
    private int enemyType;

    public BattleController(int et)
    {
        enemyType = et;
    }

    // Use this for initialization
	void Start () {
        currentState = BattleState.START;
        c1 = c2 = c3 = e1 = e2 = e3 = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
        switch(currentState)
        {
            case BattleState.START:

                battleMembers = Party.instance.characters;
                currentState = BattleState.WAITING;
                 

                break;

            case BattleState.PLAYER_CHOICE:
                break;

            case BattleState.ENEMY_CHOICE:
                break;

            case BattleState.DMG_PHASE:
                break;

            case BattleState.WAITING:



                break;

            case BattleState.WIN:
                break;

            case BattleState.LOSE:
                break;

            case BattleState.EXIT:
                break;
        }

	}
}
