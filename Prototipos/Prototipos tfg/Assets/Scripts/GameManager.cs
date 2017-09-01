using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    PAUSE,
    MAP,
    BATTLE,
    TALKING
};

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public GameObject player, inv, party, menu, enemyDB, jobManager, skillManager;
    private float playedTime;
    public List<Objective> currentObjectives;
    public GameState state = GameState.MAP;
    public int encounter_chance,rn,zona_actual;
    private int gold=10000;
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
        Instantiate(enemyDB);
        Instantiate(skillManager);
        DontDestroyOnLoad(menu);
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
        encounter_chance = -1;
        zona_actual = 1;
        currentObjectives = new List<Objective>();
        currentObjectives = this.GetComponent<ObjectiveDBController>().currentObjectives();                
        /* trozo random de codigo para probar cosas*/
        //Party.instance.characters[0].setJob("Black Mage");


    }

	// Update is called once per frame
	void Update () {

      if(state== GameState.MAP)
        {
            rn = Random.Range(0,100);

            if(rn == encounter_chance)
            {
                enterBattle();
            }
        }
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
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Party.instance.characters.ForEach(
                x => x.expGain(10, 10)
            );
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
        else
        {
            ResumeGame();
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
