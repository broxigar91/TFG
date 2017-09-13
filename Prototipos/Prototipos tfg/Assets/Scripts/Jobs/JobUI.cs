using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobUI : MonoBehaviour {

    public GameObject job;
    private JobManager jM;
    public List<Text> jobInfo;


	// Use this for initialization
	void Start () {
        jM = JobManager.instance;
        paintJobs();
        PaintJobInfo(jM.jobs[0].jobName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void paintJobs()
    {
        foreach(Job jb in jM.getAll())
        {
            GameObject j = Instantiate(job);
            j.transform.GetComponentInChildren<Text>().text = jb.jobName;
            j.transform.GetComponent<Button>().onClick.AddListener(delegate { PaintJobInfo(jb.jobName); });
            j.transform.SetParent(this.transform);
            j.transform.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void PaintJobInfo(string j)
    {
        Job jb = jM.getJob(j);

        jobInfo[0].text = jb.jobName;
        jobInfo[1].text = jb.description;
        jobInfo[2].text = jb.str + "\n\n" + jb.def + "\n\n" + jb.intelect + "\n\n" + jb.mdef + "\n\n" + jb.spe;
    }
}
