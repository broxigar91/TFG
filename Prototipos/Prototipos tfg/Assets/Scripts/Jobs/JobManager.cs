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

    public Component getScript(string j)
    {
        Component c;

        switch(j)
        {
            case "Black Mage":
                c= this.transform.GetChild(0).GetComponent<Job>();
                break;
            default:
                return null;
        }

        return c;
    }
}
