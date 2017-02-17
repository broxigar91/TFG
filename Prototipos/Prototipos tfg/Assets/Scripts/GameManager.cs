using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private Vector2 PlayerPosition;
    private float playedTime;
    public GameObject inv;
    public Party party;

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
    }

    void startInventory()
    {
        if(Inventory.inventory == null)
        {
            Instantiate(inv);
        }

        Inventory.inventory.loadState();
    }

    void startParty()
    {
        if(Party.instance == null)
        {
            Instantiate(party);
        }

        Party.instance.loadState();
    }

    //Use this for initialization
    void Start()
    {
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        if (Inventory.inventory != null)
        {
            Inventory.inventory.saveState();
        }

        if(Party.instance != null)
        {
            Party.instance.saveState();
        }
    }
}
