using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job_Base : MonoBehaviour
{

    private string jobName;
    private string jobDescription;

    //Stats-growing multiplcators
    private float hp; //health points
    private float str; //strength -> phisical attack
    private float def; //phisical defense
    private float intelect; //intelect -> magical attack
    private float mdef; //magical defense
    private float spe; //speed

    public string JobName
    {
        get { return jobName; }
        set { jobName = value;}
    }

    public string JobDescription
    {
        get { return jobDescription; }
        set { jobDescription = value; }
    }

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float Str
    {
        get { return str; }
        set { str = value; }
    }

    public float Def
    {
        get { return def; }
        set { def = value; }
    }

    public float Intelect
    {
        get { return intelect; }
        set { intelect = value; }
    }

    public float Mdef
    {
        get { return mdef; }
        set { mdef = value; }
    }

    public float Spe
    {
        get { return spe; }
        set { spe = value; }
    }
}
