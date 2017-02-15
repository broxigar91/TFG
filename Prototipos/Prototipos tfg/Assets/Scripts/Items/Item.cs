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
    /*private string itemDesc;
    private string sprite;
    private Itemtype type;
    private int goldValue;

    //parámetros de los objetos -> pociones
    private int hp_restore;
    private int status_restore;
    private bool all; //este parámetro hace referencia a si la poción hace efecto sobre toda la party

    //parámetros de los objetos -> equipables (armas y armaduras)
    private int hp;
    private int str;
    private int def;
    private int intelect;
    private int mdef;
    private int spe;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    
    public string ItemDesc
    {
        get { return itemDesc; }
        set { itemDesc = value; }
    }

    public Itemtype getType()
    {
        return type;
    }

    public int GoldValue
    {
        get { return goldValue; }
        set { goldValue = value; }
    }

    public int Hp_restore
    {
        get { return hp_restore; }
        set { hp_restore = value; }
    }

    public int Status_restore
    {
        get { return status_restore; }
        set { status_restore = value; }
    }

    public bool All
    {
        get { return all; }
        set { all = value; }
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
    */
}

[System.Serializable]
public class ItemDB
{
    public List<Item> items;
}