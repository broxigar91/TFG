using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill: MonoBehaviour {

    public enum skillType
    {
        DAMAGE,
        HEAL,
        HEAL_STATUS,
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
    public int joblvl; //nivel de trabajo necesario para utilizar la habilidad
    public int damage;
    public string job;
    public int manaCost;
    public bool canAll; //booleano que indica si la habilidad puede lanzarse a varios objetivos
    public Unit target;
    public Unit user;
    public statusType status;
    public bool magicdmg;
    public Sprite sp;
    public Animator anim;
    
    public void use()
    {
        BattleController bc = GameObject.Find("BattleManager").GetComponent<BattleController>();

        if(bc.CurrentState==BattleController.BattleState.PLAYER_CHOICE)
        {
            user = bc.getMemberOnAction();
        }
        


        switch(sType)
        {
            case skillType.DAMAGE:

                if (magicdmg)
                {
                    // target.hp = (int)(user.intelect / target.mdef * damage);
                }
                else //daño fisico
                {
                    // target.hp = (int)(user.str / target.def * damage);
                    Debug.Log("esto hace daño");
                }

                break;
            case skillType.HEAL:

                break;
            case skillType.STATUS: //provoca estados alterados


                break;
            case skillType.SPECIAL: //habilidades como libra que proporcionan informacion sobre el enemigo
                break;
            case skillType.HEAL_STATUS:
                break;
        }


        bc.info.skill = this;
        bc.CurrentState = BattleController.BattleState.SELECT_TARGET;
    }
}
