using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public RPGTalk rpgtalk;

	// Use this for initialization
	void Start ()
    {
        Player.instance.rpgtalk = rpgtalk;

	}
	
}
