using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //controlamos aqui el canvas que contiene el menu de pausa
    public GameObject menu;
    public GameObject inventoryMenu;


	// Use this for initialization
	void Start () {
        
        inventoryMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void ToggleInventory()
    {
        if(!inventoryMenu.activeInHierarchy)
        {
            inventoryMenu.SetActive(true);
        }
        else
        {
            inventoryMenu.SetActive(false);
        }
    }
}
