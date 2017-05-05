using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public GameObject e1, e2, e3;
    private int choice;
    public bool target_selected;
    
	// Use this for initialization
	void Start ()
    {
        target_selected = false;
        choice = 0;
        this.transform.position = e1.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(choice==0)
            {
                this.transform.position = e2.transform.position;
                choice = 1;
            }
            else if(choice ==1)
            {
                this.transform.position = e3.transform.position;
                choice = 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(choice==1)
            {
                this.transform.position = e1.transform.position;
                choice = 0;
            }
            else if(choice==2)
            {
                this.transform.position = e2.transform.position;
                choice = 1;
            }
        }
    }

    public int targetSelected()
    {
        GameObject.Find("SkillsContainer").SetActive(false);
        this.gameObject.SetActive(false);
        return choice;
    }

    public void Select()
    {
        target_selected = true;
    }

}
