using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobUI : MonoBehaviour {

    public GameObject job;
    private JobManager jM;


	// Use this for initialization
	void Start () {
        jM = JobManager.instance;
        paintJobs();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void paintJobs()
    {
        foreach(Job jb in jM.getAll())
        {
            GameObject j = Instantiate(job);
            j.transform.GetComponentInChildren<Text>().text = jb.name;
            j.transform.SetParent(this.transform);
            j.transform.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
