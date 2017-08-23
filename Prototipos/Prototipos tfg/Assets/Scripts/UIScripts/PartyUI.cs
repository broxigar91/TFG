using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyUI : MonoBehaviour {

    public List<GameObject> chs;
    private Party party;
    
	// Use this for initialization
	void Start () {
        chs.ForEach(x => x.SetActive(false));

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void paintParty()
    {
        Party p = Party.instance;
        int i = 0;
        foreach(Character c in p.characters)
        {
            if(c.activaded)
            {
                chs[i].SetActive(true);
                //go.transform.Find("Portrait").GetComponent<Image>().sprite = c.
                chs[i].transform.Find("Name").GetComponent<Text>().text = c.Unitname;
                chs[i].transform.Find("HP").GetComponent<Text>().text = c.hp + " / " + c.maxHp;
                //go.transform.Find("Mana").GetComponent<Text>().text=c.
                chs[i].transform.Find("Job").GetComponent<Text>().text = c.job.jobName;
                chs[i].transform.Find("Str").GetComponent<Text>().text = "Str: " + c.str;
                chs[i].transform.Find("Def").GetComponent<Text>().text = "Def: " + c.def;
                chs[i].transform.Find("Int").GetComponent<Text>().text = "Int: " + c.intelect;
                chs[i].transform.Find("MDef").GetComponent<Text>().text = "MDef: " + c.mdef;
                chs[i].transform.Find("Spe").GetComponent<Text>().text = "Spe: " + c.spe;
                chs[i].transform.SetParent(this.transform);
                i++;
            }
        }
    }


}
