using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour {

    private itemDBController db;
    private Inventory inventory;
    public GameObject item;


	// Use this for initialization
	void Start () {
        inventory = Inventory.inventory;
        db = GameManager.instance.GetComponent<itemDBController>();
        paintItems();
	}
	

    void paintItems()
    {
        foreach(InvItem it in inventory.itemList)
        {
            GameObject itemInstance = Instantiate(item);
            Item itemDetails = db.getById(it.id);
            itemInstance.transform.GetComponentInChildren<Text>().text = itemDetails.itemName;
            itemInstance.transform.SetParent(this.transform);
            itemInstance.transform.localScale = new Vector3(1, 1, 1);
            
        }
    }

    public void Reload()
    {
        List<GameObject> c=new List<GameObject>();

        for(int i =0;i<gameObject.transform.childCount;i++)
        {
            c.Add(gameObject.transform.GetChild(i).gameObject);
        }

        c.ForEach(x => Destroy(x.gameObject));

        paintItems();
    }
	// Update is called once per frame
	void Update () {
		
	}

}
