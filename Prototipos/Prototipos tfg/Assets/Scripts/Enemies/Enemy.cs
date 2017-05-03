using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Enemy: Unit{
    public int id;
    public int baseExp; //experiencia que da este enemigo
    public int zone; //zona de aparicion de los enemigos
}

[System.Serializable]
public class EnemyDB
{
    public List<Enemy> enemies;
}