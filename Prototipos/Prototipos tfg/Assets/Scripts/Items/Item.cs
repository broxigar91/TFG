using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum Itemtype
{
    POTION, //0
    WEAPON,//1
    ARMOR_HELMET, //2
    ARMOR_CHEST, //3
    ARMOR_LEGS, //4
    ARMOR_BOOTS, //5
    ARMOR_GLOVES //6
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
        if(hp_restore!=0) //cura vida
        {

        }
        else //cura estados alterados
        {

        }
    }

}

[System.Serializable]
public class ItemDB
{
    public List<Item> items;
}