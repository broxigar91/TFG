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
        Debug.Log("cant" +quant);
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
        Transform t = vendorBuy.transform.Find("ItemContainer");

        if(t.childCount!=0)
        {
            ReloadItems();
        }

        List<Item> it = new List<Item>();

        items.ForEach(
            x => it.Add(GameManager.instance.GetComponent<itemDBController>().getById(x))    
        );
               

        foreach (Item i in it)
        {
            GameObject go = Instantiate(itemPrefab);
            go.transform.Find("ItemName").GetComponent<Text>().text = i.itemName;
            go.transform.Find("ItemCost").GetComponent<Text>().text = i.goldValue.ToString();
            go.transform.Find("ItemName").GetComponent<Button>().onClick.AddListener(delegate { this.SelectItem(i.id); });
            go.transform.SetParent(t);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ReloadItems()
    {
        Transform t = vendorBuy.transform.Find("ItemContainer");

        List<GameObject> c = new List<GameObject>();

        for (int i = 0; i < t.childCount; i++)
        {
            c.Add(t.GetChild(i).gameObject);
        }

        c.ForEach(x => Destroy(x.gameObject));
    }
   



    public void checkoutInfoUpdate()
    {
        Text desc = checkPanel.transform.Find("ItemDescription").GetComponent<Text>();
        Text quantity = checkPanel.transform.Find("QuantityInfo").GetComponent<Text>();
        Text cost = checkPanel.transform.Find("Cost").GetComponent<Text>();
        

        desc.text = itemSelected.itemDesc;
        quantity.text = sl.value.ToString();
        cost.text = (itemSelected.goldValue * (int)sl.value).ToString();
    }


    public void BuyUpdate()
    {
        Buy(itemSelected.id, (int)sl.value);
    }

    public void SelectItem(int id)
    {
        itemSelected = GameManager.instance.GetComponent<itemDBController>().getById(id);
        checkoutInfoUpdate();
    }
    

    public void Exit()
    {
        displayStore();
        GameManager.instance.state = GameState.MAP;
    }
}
