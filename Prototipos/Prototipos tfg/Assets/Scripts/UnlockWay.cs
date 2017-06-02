using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWay : MonoBehaviour {

    public int objective;

	// Use this for initialization
	void Start () {
        if(GameManager.instance.gameObject.GetComponent<ObjectiveDBController>().isCompleted(objective)==true)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (GameManager.instance.gameObject.GetComponent<ObjectiveDBController>().isCompleted(objective) == true)
        {
            Destroy(gameObject);
        }
    }
}
