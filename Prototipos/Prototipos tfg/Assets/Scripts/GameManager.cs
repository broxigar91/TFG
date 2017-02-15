using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private Vector2 PlayerPosition;
    private float playedTime;
    public GameObject inv;

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

    //Use this for initialization
    void Start()
    {
        Inventory.inventory.addItem(1);
        Inventory.inventory.addItem(0);
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
    }
}
