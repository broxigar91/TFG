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
    }

    void Start()
    {
        Character[] c = this.gameObject.GetComponentsInChildren<Character>();
        foreach(Character ch in c)
        {
            characters.Add(ch);
        }
    }

    public Sprite getPortrait(string name)
    {
        return this.gameObject.transform.Find(name).GetComponent<SpriteRenderer>().sprite;
    }


    public void addToParty(string name)
    {
        Character ch = GameManager.instance.GetComponent<CharacterLoader>().getByName(name);
        if (ch != null)
        {
            characters.Add(ch);
        }
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
