using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    private string charName;
    private int hp;
    private int str;
    private int def;
    private int intelect;
    private int mdef;
    private int spe;

    public string CharName
    {
        get { return charName; }
        set { charName = value; }
    }

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Str
    {
        get { return str; }
        set { str = value; }
    }

    public int Def
    {
        get { return def; }
        set { def = value; }
    }

    public int Intelect
    {
        get { return intelect; }
        set { intelect = value; }
    }

    public int Spe
    {
        get { return spe; }
        set { spe = value; }
    }


    /*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
