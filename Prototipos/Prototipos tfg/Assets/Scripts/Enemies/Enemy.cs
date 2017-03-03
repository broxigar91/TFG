using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Enemy {

    public string enemyName;
    public int hp;
    public int str;
    public int def;
    public int intelect;
    public int mdef;
    public int spe;
}

[System.Serializable]
public class EnemyDB
{
    public List<Enemy> enemies;
}