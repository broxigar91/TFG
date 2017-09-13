using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //controlamos aqui el canvas que contiene el menu de pausa
    public GameObject menu, inventoryMenu, jobsMenu,partyMenu,objectivesMenu;

    private string lastMenu;
    
	// Use this for initialization
	void Start () {
        
        inventoryMenu.SetActive(false);
        jobsMenu.SetActive(false);
        lastMenu = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(lastMenu!="" && GameManager.instance.state==GameState.PAUSE)
            {
                Invoke("Toggle" + lastMenu, 0.0f);
            }
        }
	}

    public void ToggleInventory()
    {
        if(!inventoryMenu.activeInHierarchy)
        {
            inventoryMenu.SetActive(true);
            lastMenu = "Inventory";
        }
        else
        {
            inventoryMenu.SetActive(false);
            lastMenu = "";
        }
    }

    public void ToggleJobs()
    {
        if (!jobsMenu.activeInHierarchy)
        {
            jobsMenu.SetActive(true);
            lastMenu = "Jobs";
        }
        else
        {
            jobsMenu.SetActive(false);
            lastMenu = "";
        }
    }


    public void ToggleParty()
    {
        if (!partyMenu.activeInHierarchy)
        {
            partyMenu.SetActive(true);
            partyMenu.GetComponent<PartyUI>().paintParty();
            lastMenu = "Party";
        }
        else
        {
            partyMenu.SetActive(false);
            lastMenu = "";
            Debug.Log(lastMenu + " KIIIII");
        }
        
    }

    public void ToggleObjectives()
    {
        if(!objectivesMenu.activeInHierarchy)
        {
            objectivesMenu.SetActive(true);
            objectivesMenu.GetComponentInChildren<ObjectivesUI>().DisplayObjectives();
            lastMenu = "Objectives";
        }
        else
        {
            objectivesMenu.SetActive(false);
            lastMenu = "";
        }
    }

    public void CloseAll()
    {
        inventoryMenu.SetActive(false);
        jobsMenu.SetActive(false);
        partyMenu.SetActive(false);
        objectivesMenu.SetActive(false);
    }
}
