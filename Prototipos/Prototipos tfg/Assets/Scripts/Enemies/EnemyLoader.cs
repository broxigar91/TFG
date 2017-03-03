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
        return db.enemies.Find(enem => enem.enemyName == name);
    }
}
