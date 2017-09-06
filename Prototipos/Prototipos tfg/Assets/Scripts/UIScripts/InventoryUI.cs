using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour {

    private itemDBController db;
    private Inventory inventory;
    public GameObject item,chContainer;
    private Item it;

	// Use this for initialization
	void Start () {
        inventory = Inventory.inventory;
        db = GameManager.instance.GetComponent<itemDBController>();
        paintItems();
        chContainer.SetActive(false);
	}
	

    void paintItems()
    {
        foreach(InvItem it in inventory.itemList)
        {
            GameObject itemInstance = Instantiate(item);
            Item itemDetails = db.getById(it.id);
            itemInstance.transform.GetComponentInChildren<Text>().text = itemDetails.itemName;

            itemInstance.transform.GetComponentInChildren<Button>().onClick.AddListener(delegate { this.Select(itemDetails); } );
            
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
        chContainer.SetActive(false);
        paintItems();
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void Select(Item i)
    {
        it = i;
        chContainer.SetActive(true);
    }

    private void OnEnable()
    {
        if(this.transform.childCount!=0)
            Reload();
    }

    public void ItemInteraction(string x)
    {
        Character c = Party.instance.characters.Find(k=> k.Unitname == x);

        if (it.type == Itemtype.HP_POTION || it.type== Itemtype.STATUS_POTION)
        {
            if(c.m_hp < c.maxHp)
            {
                c.m_hp += it.hp_restore;
                if(c.m_hp > c.maxHp)
                {
                    c.m_hp = c.maxHp;
                }
            }
        }
        else
        {
           c.equipItem(it);
        }
    }

}
