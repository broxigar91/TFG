using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour {

    public GameObject enemydb;
    public Dictionary<string,int> cosis;

	// Use this for initialization
	void Start () {
        Instantiate(enemydb);
        cosis = new Dictionary<string, int>();
        cosas();
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


   void cosas()
    {
        Transform sk;
        Debug.Log(enemydb.transform.GetChild(0).transform.childCount);
        cosis.Add("Black Mage", 2);
        Debug.Log(cosis["Black Mage"]);
        sk = enemydb.transform.GetChild(0).GetChild(1);
        if(sk.name == "Piro")
        {
            sk.GetComponent<Piro>().use();
            Debug.Log(enemydb.transform.GetChild(0).childCount);
        }
        else if(sk.name == "Heal")
        {
            sk.GetComponent<Heal>().use();
        }
    }
}
