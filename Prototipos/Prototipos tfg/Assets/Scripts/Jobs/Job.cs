﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour {

    
    public string jobName;
    public string description;

    //multiplicadores
    public float hp;
    public float str;
    public float def;
    public float intelect;
    public float mdef;
    public float spe;
    //public List<int> lvlpoints = new List<int>(9);//nivel inicial del job =1 + 9 niveles  = 10 niveles de job
    public Dictionary<int, int> joblvl;
    public int count;

    void Start()
    {
        joblvl = new Dictionary<int, int>(9);//nivel inicial del job =1 + 9 niveles  = 10 niveles de job
       /* lvlpoints[0] = 30;
        lvlpoints[1] = 100;
        lvlpoints[2] = 300;
        lvlpoints[3] = 400;
        lvlpoints[4] = 800;
        lvlpoints[5] = 1500;
        lvlpoints[6] = 2500;
        lvlpoints[7] = 5000;
        lvlpoints[8] = 8000;
        */
        //Establece los puntos de experiencia para subir el nivel de trabajo
        joblvl.Add(1, 30);
        joblvl.Add(2, 100);
        joblvl.Add(3, 300);
        joblvl.Add(4, 400);
        joblvl.Add(5, 800);
        joblvl.Add(6, 1500);
        joblvl.Add(7, 2500);
        joblvl.Add(8, 5000);
        joblvl.Add(9, 8000);
        count = joblvl.Count;
    }


    

}
