using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyLoader : MonoBehaviour {

    public EnemyDB db;

	// Use this for initialization
	void Start () {
        string datos = File.ReadAllText(Application.dataPath + "/Resources/enemies.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<EnemyDB>(datos);
    }
	
    public Enemy getbyName(string name)
    {
        return db.enemies.Find(enem => enem.name == name);
    }

    public List<Enemy> getByZone(int z)
    {
        return db.enemies.FindAll(enem => enem.zone == z);
    }


    public List<Enemy> toBattle(int z)
    {
        List<Enemy> aux = getByZone(z);
        List<Enemy> en = new List<Enemy>();
        int rn;

        while (en.Count < 3)
        {
            rn = Random.Range(0, aux.Count);
            en.Add(aux[rn]);
        }

        return en;
    }
}
