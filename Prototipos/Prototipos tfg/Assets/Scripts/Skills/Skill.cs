using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill: MonoBehaviour {

    public enum skillType
    {
        DAMAGE,
        HEAL,
        STATUS,
        SPECIAL
    }

    public enum statusType
    {
        NONE,
        POISON,
        BLIND,
        HASTE,
        SLOW,
        CURSED
    }

    public string abilityName;
    public string description;
    public skillType sType;
    public int damage;
    public string job;
    public int manaCost;
    public bool canAll; //booleano que indica si la habilidad puede lanzarse a varios objetivos
    public Unit target;
    public Unit user;
    public statusType status;
    public bool magicdmg;

    
    public void use()
    {
        switch(sType)
        {
            case skillType.DAMAGE:

                if (magicdmg)
                {

                }
                else
                {

                }

                break;
            case skillType.HEAL:

                break;
            case skillType.STATUS:


                break;
            case skillType.SPECIAL:
                break;
        }
    }
}
