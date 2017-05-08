using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public GameObject e1, e2, e3, c1, c2, c3;
    private int choice;
    public bool target_selected;
    private bool enemy;
	// Use this for initialization
	void Start ()
    {
        enemy = true;
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
            if(enemy)
            {
                if (choice == 0)
                {
                    this.transform.position = e2.transform.position;
                    choice = 1;
                }
                else if (choice == 1)
                {
                    this.transform.position = e3.transform.position;
                    choice = 2;
                }
            }
            else
            {
                if (choice == 0)
                {
                    this.transform.position = c2.transform.position;
                    choice = 1;
                }
                else if (choice == 1)
                {
                    this.transform.position = c3.transform.position;
                    choice = 2;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(enemy)
            {
                if (choice == 1)
                {
                    this.transform.position = e1.transform.position;
                    choice = 0;
                }
                else if (choice == 2)
                {
                    this.transform.position = e2.transform.position;
                    choice = 1;
                }
            }
            else
            {
                if (choice == 1)
                {
                    this.transform.position = c1.transform.position;
                    choice = 0;
                }
                else if (choice == 2)
                {
                    this.transform.position = c2.transform.position;
                    choice = 1;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(enemy)
            {
                if(choice==0)
                {
                    this.transform.position = c1.transform.position;
                }
                else if(choice==1)
                {
                    this.transform.position = c2.transform.position;
                }
                else
                {
                    this.transform.position = c3.transform.position;
                }
                enemy = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!enemy)
            {
                if (choice == 0)
                {
                    this.transform.position = e1.transform.position;
                }
                else if (choice == 1)
                {
                    this.transform.position = e2.transform.position;
                }
                else
                {
                    this.transform.position = e3.transform.position;
                }
                enemy = true;
            }
        }
    }

    public int targetSelected()
    {
        
        this.gameObject.SetActive(false);
        return choice;
    }

    public void Select()
    {
        target_selected = true;
    }

    public bool enemySelected()
    {
        return enemy;
    }
}
