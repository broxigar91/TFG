﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterLoader : MonoBehaviour {

    public CharDB db;

	// Use this for initialization
	void Start () {
        //cargamos la party
        string datos = File.ReadAllText(Application.dataPath + "/Resources/characters.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<CharDB>(datos);
        Debug.Log(db.characters[0].name);
	}

    public Character getByName(string name)
    {
        return db.characters.Find(character => character.Unitname == name);
    }

}
