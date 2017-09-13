using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public static SkillManager instance;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public List<Skill> skills;
	// Use this for initialization
	void Start () {
        Skill[] s = gameObject.GetComponentsInChildren<Skill>();

        foreach(Skill sk in s)
        {
            skills.Add(sk);
        }
        Debug.Log(canUse("Black Mage",1).Count+ "asdasd");
	}
	
    public List<Skill> getByJob(string jobName)
    {
        return skills.FindAll(s => s.job == jobName);
    }

    public List<Skill> canUse(string jobName, int lvl)
    {
        return skills.FindAll(s => s.job == jobName && s.joblvl == lvl);
    }

}
