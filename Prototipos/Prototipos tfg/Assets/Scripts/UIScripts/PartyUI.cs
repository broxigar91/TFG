using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyUI : MonoBehaviour {

    public List<GameObject> chs;
    public List<Text> labels; //etiquetas para el preview de stats
    public Text previewText;
    public GameObject previewPanel;
    
    
	// Use this for initialization
	void Start () {
        
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
                Dropdown d;
                chs[i].SetActive(true);
                chs[i].transform.Find("Portrait").GetComponent<Image>().sprite = p.getPortrait(c.Unitname);
                chs[i].transform.Find("Name").GetComponent<Text>().text = c.Unitname;
                chs[i].transform.Find("HP").GetComponent<Text>().text = c.hp + " / " + c.maxHp;
                //go.transform.Find("Mana").GetComponent<Text>().text=c.
                chs[i].transform.Find("Level").GetComponent<Text>().text = "Nivel " + c.level;
                //se borran y vuelven a rellenar las opciones del dropdown con los nombres de todos los trabajos
                d = chs[i].transform.Find("Job").GetComponent<Dropdown>();
                d.options.Clear();
                d.AddOptions(JobManager.instance.getNames());
                //el valor por defecto es la opcion que contiene el nombre del trabajo equipado
                //d.value = d.options.FindIndex(x => x.text == c.job.jobName);
                //d.onValueChanged.AddListener(delegate { ChangeJob(i); });

                chs[i].transform.Find("StatValue").GetComponent<Text>().text = c.m_str + "\n\n" + c.m_def + "\n\n" + c.m_int + "\n\n" + c.m_mdef + "\n\n" + c.m_spe;
               // chs[i].transform.SetParent(this.transform);
                i++;
            }
        }
    }

    public void ChangeJob(int i)
    {

        Debug.Log("CAMBIO");
        Party p = Party.instance;
        Dropdown d = chs[i].transform.Find("Job").GetComponent<Dropdown>();

        p.characters[i].changeJob(d.captionText.text);

        chs[i].transform.Find("StatValue").GetComponent<Text>().text = p.characters[i].m_str + "\n\n" + p.characters[i].m_def + "\n\n" + p.characters[i].m_int + "\n\n" + p.characters[i].m_mdef + "\n\n" + p.characters[i].m_spe;
    }


    

}
