using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character{


    public string charName;
    public int hp;
    public int str;
    public int def;
    public int intelect;
    public int mdef;
    public int spe;
    public int level;
    public int currentExp; //experiencia actual del personaje
    public int lvlupExp; //experiencia necesaria para subir de nivel
    public bool activaded; //esta variable se usa para activar al personaje dentro de la party.


    public void expGain(int expGained)
    {
        currentExp += expGained;

        if(currentExp >= lvlupExp)
        {
            currentExp = currentExp - lvlupExp; //si es = sera 0, si es > será la diferencia
            lvlUp();
        }

    }

    public void lvlUp()
    {
        level++;
        lvlupExp = level * 100; //1 -> 100, 2-> 200, 3-> 300
    }
}
