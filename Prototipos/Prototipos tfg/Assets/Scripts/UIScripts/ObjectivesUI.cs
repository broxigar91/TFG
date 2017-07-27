using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjectivesUI : MonoBehaviour {

    private ObjectiveDBController ob;
    public GameObject objectivePrebab;

    public void DisplayObjectives()
    {

        if(transform.childCount > 0)
        {
            ReloadObjectives();
        }

        List<Objective> lob;
        ob = GameManager.instance.GetComponent<ObjectiveDBController>();
        lob = ob.currentObjectives();

        foreach(Objective o in lob)
        {
            GameObject go = Instantiate(objectivePrebab);
            go.GetComponent<Text>().text = o.id.ToString();
            go.transform.SetParent(this.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void ReloadObjectives()
    {
        List<GameObject> c = new List<GameObject>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            c.Add(gameObject.transform.GetChild(i).gameObject);
        }

        c.ForEach(x => Destroy(x.gameObject));
    }

}
