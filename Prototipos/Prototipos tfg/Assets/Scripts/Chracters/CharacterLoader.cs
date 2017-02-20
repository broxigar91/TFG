using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterLoader : MonoBehaviour {

    public List<Character> charDB;

	// Use this for initialization
	void Start () {
        //cargamos la party
        string datos = File.ReadAllText(Application.dataPath + "/Resources/characters.json"); //establezco la ruta donde se encuentra el fichero json
        charDB = JsonUtility.FromJson<List<Character>>(datos);
	}



}
