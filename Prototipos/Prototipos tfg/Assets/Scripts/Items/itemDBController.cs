using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class itemDBController : MonoBehaviour {

    public itemDB db;

	// Use this for initialization
	void Start () {
        string data = File.ReadAllText(Application.dataPath + "/Scripts/Items/items.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<itemDB>(data);
	}

    public Item getById(int id)
    {
        //para cada objedo dentro de db compara el id y nos devuelve el objeto en caso de coincidir
        return db.items.Find(item => item.Id == id);
    }

}
