using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vendor : MonoBehaviour {

    public List<int> items;
    public GameObject vendorBuy,checkPanel,itemPrefab;
    public Item itemSelected;
    public Slider sl;

    public void Buy(int id, int quant)
    {
        Inventory inv = Inventory.inventory;

        if(inv.inInventory(id))
        {
            inv.addQuantity(id, quant);
        }
    }

    public void displayStore()
    {
        if (vendorBuy.activeInHierarchy == false)
        {
            vendorBuy.SetActive(true);
            LoadItems();
            itemSelected = GameManager.instance.GetComponent<itemDBController>().getById(items[0]);
            checkoutInfoUpdate();
        }
        else
        {
            vendorBuy.SetActive(false);
        }
    }


    public void LoadItems()
    {
        List<Item> it = new List<Item>();

        items.ForEach(
            x => it.Add(GameManager.instance.GetComponent<itemDBController>().getById(x))    
        );


        Transform t = vendorBuy.transform.Find("ItemContainer");
        
        foreach(Item i in it)
        {
            GameObject go = Instantiate(itemPrefab);
            go.transform.Find("ItemName").GetComponent<Text>().text = i.itemName;
            go.transform.Find("ItemCost").GetComponent<Text>().text = i.goldValue.ToString();
            go.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate { this.SelectItem(i.id); });
            go.transform.SetParent(t);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }
   



    public void checkoutInfoUpdate()
    {
        Text desc = checkPanel.transform.Find("ItemDescription").GetComponent<Text>();
        Text quantity = checkPanel.transform.Find("QuantityInfo").GetComponent<Text>();
        Text cost = checkPanel.transform.Find("Cost").GetComponent<Text>();
        

        desc.text = itemSelected.itemDesc;
        quantity.text = sl.value.ToString();
        cost.text = (itemSelected.goldValue * (int)sl.value).ToString();
        checkPanel.GetComponentInChildren<Button>().onClick.AddListener(delegate { Buy(itemSelected.id,(int)sl.value); });

    }


    public void SelectItem(int id)
    {
        itemSelected = GameManager.instance.GetComponent<itemDBController>().getById(id);
        checkoutInfoUpdate();
    }


    
}
