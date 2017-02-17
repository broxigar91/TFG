using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/*public enum Itemtype
{
    POTION, //0
    WEAPON_SWORD_1H, //1
    WEAPON_SWORD_2H, //2 
    WEAPON_SHIELD, //3
    WEAPON_ROD, //4
    WEAPON_AXE_1H, //5
    WEAPON_AXE_2H, //6
    WEAPON_DAGGER, //7
    ARMOR_HELMET, //8
    ARMOR_CHEST, //9
    ARMOR_LEGS, //10
    ARMOR_BOOTS, //11
    ARMOR_GLOVES //12
}*/

[System.Serializable]
public class Item {

    public int id;
    public string itemName;
    public string itemDesc;
    public string sprite;
    //private Itemtype type;
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
    
}

[System.Serializable]
public class ItemDB
{
    public List<Item> items;
}