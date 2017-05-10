using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class itemDBController : MonoBehaviour {

    public ItemDB db;
    public Dictionary<int, Sprite> itemSprites;

	// Use this for initialization
	void Start () {
        string datos = File.ReadAllText(Application.dataPath + "/Resources/itemdatabase.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<ItemDB>(datos);

        //ademas de cargar los datos de los objetos, se cargan los sprites de los objetos.
        /*itemSprites = new Dictionary<int, Sprite>();
        foreach(Item it in db.items)
        {
            string ruta = Application.dataPath + "/Resources/" + it.rutaSprite + ".png";
            if(File.Exists(ruta))
            {
                Sprite sprite = Resources.Load<Sprite>(it.rutaSprite);
                itemSprites.Add(it.id, sprite);
            }
        }*/
        
	}

    public Item getById(int id)
    {
        //para cada objedo dentro de db compara el id y nos devuelve el objeto en caso de coincidir
        return db.items.Find(item => item.id == id);
    }

    public bool exist(int id)
    {
        return db.items.Exists(item => item.id == id);
    }

    public List<Item> getPotions()
    {
        return db.items.FindAll(item => item.type == Itemtype.HP_POTION && item.type == Itemtype.STATUS_POTION);
    }

}
