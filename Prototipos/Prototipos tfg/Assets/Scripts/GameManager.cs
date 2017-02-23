using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameState state = GameState.MAP;

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
        if(Player.instance==null)
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
    }

	// Update is called once per frame
	void Update () {
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
}
