using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour {
    
    public List<string> getAll()
    {
        List<string> j = new List<string>();

        for(int i=0;i<this.transform.childCount;i++)
        {
            j.Add(this.transform.GetChild(i).name);
        }

        return j;
    }

    public Job getScript(string j)
    {
        Job job;

        switch(j)
        {
            case "Black Mage":
                job= this.transform.GetChild(0).GetComponent<Job>();
                break;
            default:
                return null;
        }

        return job;
    }

    public List<string> getSkills(string j)
    {
        List<string> skills = new List<string>();
        
       /* switch (j)
        {
            case "Black Mage":
                
                for(int i=0;i< this.transform.GetChild(0).transform.GetChild(0).childCount;i++)
                {
                    skills.Add(this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(i).name);
                }
                break;
            default:
                return null;
        }*/

        Transform job = this.transform.Find(j);

        for(int i=0; i<job.transform.childCount;i++)
        {
            for(int k=0;k<job.GetChild(i).transform.childCount;k++)
            {
                skills.Add(job.GetChild(i).transform.GetChild(k).name);
            }
            
        }

        return skills;
    }
}
