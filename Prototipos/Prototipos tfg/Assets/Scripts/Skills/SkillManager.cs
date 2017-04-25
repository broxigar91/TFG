using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {


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
	
    List<Skill> getByJob(string jobName)
    {
        return skills.FindAll(s => s.job == jobName);
    }

    List<Skill> canUse(string jobName, int lvl)
    {
        return skills.FindAll(s => s.job == jobName && s.joblvl == lvl);
    }

}
