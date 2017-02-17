using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class itemDBController : MonoBehaviour {

    public ItemDB db;

	// Use this for initialization
	void Start () {
        string datos = File.ReadAllText(Application.dataPath + "/Resources/itemdatabase.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<ItemDB>(datos);
        
	}

    public Item getById(int id)
    {
        //para cada objedo dentro de db compara el id y nos devuelve el objeto en caso de coincidir
        return db.items.Find(item => item.Id == id);
    }

    public bool exist(int id)
    {
        return db.items.Exists(item => item.Id == id);
    }

}
