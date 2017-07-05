using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorPanel : MonoBehaviour {

    public GameObject checkPanel,itemList,vendorBuy;
    private int itemPrice;

    public int ItemPrice
    {
        get { return itemPrice; }
        set { itemPrice = value; }
    }

    public void checkoutInfoUpdate()
    {
        Text quantity = checkPanel.transform.Find("QuantityInfo").GetComponent<Text>();
        Text cost = checkPanel.transform.Find("Cost").GetComponent<Text>();
        Slider sl = checkPanel.transform.Find("Quantity").GetComponent<Slider>();


        quantity.text = sl.value.ToString();
        cost.text = (ItemPrice * sl.value).ToString();

    }

    public void DisplayItems()
    {

    }

    public void ToggleBuyMenu()
    {
        if(vendorBuy.activeInHierarchy==false)
        {
            vendorBuy.SetActive(true);
        }
        else
        {
            vendorBuy.SetActive(false);
        }
    }
}
