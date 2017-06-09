using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vendor : MonoBehaviour {

    public List<InvItem> items;



    public void sell(int id)
    {
        items.Find(x => x.id == id).quantity--;
    }
}
