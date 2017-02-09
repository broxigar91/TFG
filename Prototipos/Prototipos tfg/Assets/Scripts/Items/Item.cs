using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    private int id;
    private string itemName;
    
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
}

public struct itemDB
{
    public List<Item> items;
}