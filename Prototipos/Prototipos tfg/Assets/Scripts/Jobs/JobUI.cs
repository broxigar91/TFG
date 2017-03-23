using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobUI : MonoBehaviour {

    public GameObject job;
    private JobManager jm;


	// Use this for initialization
	void Start () {
        jm = GameManager.instance.jobManager.GetComponent<JobManager>();
        paintJobs();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void paintJobs()
    {
        List<string> jobs = jm.getAll();

        foreach(string s in jobs)
        {
            GameObject j = Instantiate(job);
            j.transform.GetComponentInChildren<Text>().text = s;
            j.transform.SetParent(this.transform);
            j.transform.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
