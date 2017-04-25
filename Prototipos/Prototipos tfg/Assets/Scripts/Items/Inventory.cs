using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Inventory : MonoBehaviour {

    public static Inventory inventory;
    public List<InvItem> itemList;
    private int itemLimit = 5;
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
        //si el inventario no esta lleno...
        if(GameManager.instance.GetComponent<itemDBController>().exist(id) && canAdd(id))
        {
            //si ya esta en el inventario se incrementa la cantidad
            if(inInventory(id))
            {
                addQuantity(id, 1);
            }
            else
            {
                itemList.Add(new InvItem(id));
                //checkear para objetivo
            }
               
        }
    }

    public bool inInventory(int id)
    {
        return itemList.Exists(item => item.id == id);
    }

    public void addQuantity(int id, int q)
    {
        InvItem it = itemList.Find(item => item.id == id);
        if (inInventory(id) && it.quantity < 99)
        {
            it.quantity += q;
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

    public bool canAdd(int id)
    {
        return itemList.Count < itemLimit;
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