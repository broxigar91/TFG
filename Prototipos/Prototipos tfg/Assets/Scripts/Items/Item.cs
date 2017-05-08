using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum Itemtype
{
    HP_POTION, //0
    STATUS_POTION,//1
    WEAPON,//2
    ARMOR_HELMET, //3
    ARMOR_CHEST, //4
    ARMOR_LEGS, //5
    ARMOR_BOOTS, //6
    ARMOR_GLOVES //7
}

[System.Serializable]
public class Item {

    public int id;
    public string itemName;
    public string itemDesc;
    public string rutaSprite;
    public Itemtype type;
    public int goldValue;

    //parámetros de los objetos -> pociones
    public int hp_restore;
    public int status_restore;
    private bool all; //este parámetro hace referencia a si la poción hace efecto sobre toda la party

    //parámetros de los objetos -> equipables (armas y armaduras)
    public int hp;
    public int str;
    public int def;
    public int intelect;
    public int mdef;
    public int spe;


    public void use()
    {
        BattleController bc = GameObject.Find("BattleManager").GetComponent<BattleController>();
        bc.info.it = this;
        bc.CurrentState = BattleController.BattleState.SELECT_TARGET;
    }

}

[System.Serializable]
public class ItemDB
{
    public List<Item> items;
}