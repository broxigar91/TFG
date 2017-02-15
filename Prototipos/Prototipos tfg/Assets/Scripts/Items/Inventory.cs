using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Inventory : MonoBehaviour {

    public static Inventory inventory;
    public List<InvItem> itemList;
    void Awake()
    {
        if (inventory == null)
        {
            inventory = this;
        }
        else if (inventory != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    public void loadInventory()
    {
        itemList = new List<InvItem>();
    }

    public void addItem(int id)
    {
        //busco en la base de datos si ese item existe
        if(GameManager.instance.GetComponent<itemDBController>().exist(id))
        {
            itemList.Add(new InvItem(id));
        }
    }

    public bool inInventory(int id)
    {
        return itemList.Exists(item => item.id == id);
    }

    public void addQuantity(int id, int q)
    {
        if(inInventory(id))
        {
            itemList.Find(item => item.id == id).quantity += q;
        }
    }

    public void deleteItem(int id)
    {
        if(inInventory(id))
        {
            itemList.Remove(itemList.Find(item => item.id == id));
        }
    }

    public void saveState()
    {
        string inventoyData = JsonUtility.ToJson(this);
        File.WriteAllText(Application.dataPath + "/Resources/inventory.json", inventoyData);
    }

    public void loadState()
    {
        if (File.Exists(Application.dataPath + "/Resources/inventory.json"))
        {
            string inventoryData = File.ReadAllText(Application.dataPath + "/Resources/inventory.json");
            JsonUtility.FromJsonOverwrite(inventoryData, this);
        }
                       
    }
    
}

[System.Serializable]
public class InvItem
{
    public int id;
    public int quantity;

    public InvItem(int idItem = -1, int itemQuantity =0)
    {
        id = idItem;
        quantity = itemQuantity;
    }
}