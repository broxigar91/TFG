﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //private int c1, c2, c3, e1, e2, e3;
    private int enemyType;
    private float waitTime = 10.0f;
    private float cd1;
    private int pchoice;
    private bool actionRealized;
    public Image c1, c2, c3;//, e1, e2, e3;
    public GameObject actionPanel;


    // Use this for initialization
	void Start () {
        currentState = BattleState.START;
        actionRealized = false;
        actionPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
        switch(currentState)
        {
            case BattleState.START:
                
                //battleMembers = Party.instance.characters;
                c1.fillAmount = 0.0f;
                c2.fillAmount = 0.0f;
                c3.fillAmount = 0.0f;
                currentState = BattleState.WAITING;
              
                break;

            case BattleState.PLAYER_CHOICE:

                if(actionPanel.activeInHierarchy==false)
                {
                    actionPanel.SetActive(true);
                }

                if(actionRealized==true)
                {
                    if(pchoice==0)
                    {
                        c1.fillAmount = 0.0f;
                    }
                    else if(pchoice == 1)
                    {
                        c2.fillAmount = 0.0f;
                    }
                    actionRealized = false;
                    currentState = BattleState.WAITING;
                }


                break;

            case BattleState.ENEMY_CHOICE:
                break;

            case BattleState.DMG_PHASE:
                break;

            case BattleState.WAITING:

                actionPanel.SetActive(false);
                

                if (c1.fillAmount!=1.0f)
                {
                    c1.fillAmount += 1.0f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 0;
                    currentState = BattleState.PLAYER_CHOICE;
                }

                if (c2.fillAmount != 1.0f)
                {
                    c2.fillAmount += 0.8f / waitTime * Time.deltaTime;
                }
                else
                {
                    pchoice = 1;
                    currentState = BattleState.PLAYER_CHOICE;
                }

                break;

            case BattleState.WIN:
                break;

            case BattleState.LOSE:
                break;

            case BattleState.EXIT:
                GameManager.instance.state = GameState.MAP;
                SceneManager.LoadScene("Prototipo movimiento mapa");
                break;
        }

	}


    public void Attack()
    {
        Debug.Log("Accion del jugador" + pchoice);
        actionRealized = true;
    }

    public void Exit()
    {
        currentState = BattleState.EXIT;
    }
}