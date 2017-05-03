using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public GameObject skillItem;

	// Use this for initialization
	void Start () {
        paintSkills();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void paintSkills()
    {
        BattleController bc = GameObject.Find("BattleManager").GetComponent<BattleController>();
        Character c = bc.getMemberOnAction();
        List<Skill> sk = SkillManager.instance.canUse(c.job.jobName,c.jobsInfo[c.job.jobName].currentJoblvl);

        foreach(Skill s in sk)
        {
            GameObject instanciaSkill = Instantiate(skillItem);
            instanciaSkill.transform.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = s.abilityName;
            instanciaSkill.transform.GetComponentInChildren<Text>().text = s.manaCost.ToString();
            instanciaSkill.transform.SetParent(this.transform);
        }

    }
}
