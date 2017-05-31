using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject startPosition;


	// Use this for initialization
	void Start ()
    {
        Player.instance.transform.position = startPosition.transform.position;
	}
	
}
