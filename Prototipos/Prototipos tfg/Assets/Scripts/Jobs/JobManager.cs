using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour {

    public static JobManager instance;
    public List<Job> jobs;


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
        
        for(int i = 0; i < gameObject.transform.childCount;i ++)
        {
            jobs.Add(gameObject.transform.GetChild(i).GetComponent<Job>());
        }
        Debug.Log(jobs.Count);
        Debug.Log(jobs[0].jobName);
    }

    public Job getJob(string jName)
    {
        Debug.Log(jobs.Count+"sssssss");
        return jobs.Find(j=> j.jobName == jName);
    }

    public List<Job> getAll()
    {
        Debug.Log(jobs.Count + " aaaaaaaaaa");
        return jobs;
    }
}
