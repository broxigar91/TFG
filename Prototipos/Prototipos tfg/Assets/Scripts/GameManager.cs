﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    PAUSE,
    MAP,
    BATTLE
};

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject player;
    private float playedTime;
    public GameObject inv;
    public GameObject party;
    public GameObject menu;
    public GameState state = GameState.MAP;
    public int encounter_chance,rn,zona_actual;
    public GameObject jobManager;

    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        startInventory();
        startPlayer();
        startParty();
        startJobManager();
    }

    void startJobManager()
    {
        Instantiate(jobManager);
    }

    void startInventory()
    {
        if(Inventory.inventory == null)
        {
            Instantiate(inv);
        }

        Inventory.inventory.loadState();
    }


    void startPlayer()
    {
        if (Player.instance == null)
        {
            Instantiate(player);
        }
    }
    void startParty()
    {
        if(Party.instance == null)
        {
            Instantiate(party);
        }

        //Party.instance.loadState();
    }

    //Use this for initialization
    void Start()
    {
        menu.SetActive(false);
        encounter_chance = 4;
        zona_actual = 1;


        /* trozo random de codigo para probar cosas*/
        //Party.instance.characters[0].setJob("Black Mage");


    }

	// Update is called once per frame
	void Update () {

       /* if(state== GameState.MAP)
        {
            rn = Random.Range(0,100);

            if(rn == encounter_chance)
            {
                enterBattle();
            }
        }*/
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }

        if(Input.GetKeyDown(KeyCode.I) && menu.activeInHierarchy)
        {
            this.GetComponent<PauseMenu>().ToggleInventory();
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            Party.instance.characters[0].setJob("Black Mage");
            Debug.Log(Party.instance.characters[0].job.jobName);
            List<string> s = jobManager.GetComponent<JobManager>().getSkills(Party.instance.characters[0].job.jobName);
            foreach(string st in s)
            {
                Debug.Log(st);
            }
        }
    }

    void OnDestroy()
    {

    }

    public void SaveGame()
    {
        if (Inventory.inventory != null)
        {
            Inventory.inventory.saveState();
        }

        if (Party.instance != null)
        {
            Party.instance.saveState();
        }
    }

    public void TogglePauseMenu()
    {
        //comprobamos que el canvas que muestra el menu esta desactivado
        if(!menu.activeInHierarchy)
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
            state = GameState.PAUSE;
        }
    }

    public void ToggleInventory()
    {
        this.GetComponent<PauseMenu>().ToggleInventory();
    }

    public void ResumeGame()
    {
        if(menu.activeSelf)
        {
            menu.SetActive(false);
            Time.timeScale = 1.0f;
            state = GameState.MAP;
        }
    }


    public void enterBattle()
    {
        state = GameState.BATTLE;
        
        SceneManager.LoadScene("Batalla");
       
    }
}
