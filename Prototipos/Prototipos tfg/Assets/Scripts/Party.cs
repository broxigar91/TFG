using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Party : MonoBehaviour {

    public static Party instance = null;
    public List<Character> characters;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        //cargamos de fichero todos los personajes jugables, tendran un atributo para reflejar si estan activos o no
        //posiblemente esto sea mas optimo si se crea una base de datos aparte y progresivamente se añaden a la lista (?)...  CONSULTAR CON MIGUEL
        string datos = File.ReadAllText(Application.dataPath + "/Resources/characters.json"); //establezco la ruta donde se encuentra el fichero json
        instance.characters = JsonUtility.FromJson<List<Character>>(datos);
    }

    public void addToParty(Character ch)
    {
        characters.Add(ch);
    }

    public void setExp()
    {
        
    }

    public void saveState()
    {
        string inventoyData = JsonUtility.ToJson(this);
        File.WriteAllText(Application.dataPath + "/Resources/party.json", inventoyData);
    }

    public void loadState()
    {
        if (File.Exists(Application.dataPath + "/Resources/party.json"))
        {
            string inventoryData = File.ReadAllText(Application.dataPath + "/Resources/party.json");
            JsonUtility.FromJsonOverwrite(inventoryData, this);
        }

    }
}
