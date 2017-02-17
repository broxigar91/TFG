using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //cargamos la party
		if(Party.instance !=null)
        {
            string datos = File.ReadAllText(Application.dataPath + "/Resources/characters.json"); //establezco la ruta donde se encuentra el fichero json
            Party.instance.characters = JsonUtility.FromJson<List<Character>>(datos);
        }
	}
}
