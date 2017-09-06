using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

    public List<GameObject> enemies, chars;
    private int choice;
    public bool target_selected;
    private bool enemy;
    int i, j;
	// Use this for initialization
	void Start ()
    {
        enemy = true;
        target_selected = false;
        choice = 0;

        i = enemies.FindIndex(x => x.activeInHierarchy == true);

        this.transform.position = enemies[i].transform.position;
    }
	
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(enemy)
            {
                if (i < enemies.Count - 1)
                {
                    j = enemies.FindIndex(i + 1, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                    //Debug.Log(i);

                }
                else
                {
                    i = 0;
                    j = enemies.FindIndex(i, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                }

                if (j != -1)
                    this.transform.position = enemies[j].transform.position;
            }
            else
            {
                if (i < chars.Count - 1)
                {
                    j = chars.FindIndex(i + 1, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                    //Debug.Log(i);

                }
                else
                {
                    i = 0;
                    j = chars.FindIndex(i, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                }

                if (j != -1)
                    this.transform.position = chars[j].transform.position;
            }
            i = j;
            choice = j;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(enemy)
            {
                if (i > 0)
                {
                    j = enemies.FindIndex(i -1, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                    //Debug.Log(i);

                }
                else
                {
                    i = 2;
                    j = enemies.FindIndex(i, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                }

                if (j != -1)
                    this.transform.position = enemies[j].transform.position;
            }
            else
            {
                if (i > 0)
                {
                    j = chars.FindIndex(i - 1, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                    //Debug.Log(i);

                }
                else
                {
                    i = 2;
                    j = chars.FindIndex(i, x => x.activeInHierarchy == true && x.transform.position != this.transform.position);
                }

                if (j != -1)
                    this.transform.position = chars[j].transform.position;
            }
            i = j;
            choice = j;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(enemy)
            {
                this.transform.position = chars[i].transform.position;
                enemy = false;
                choice = i + 3;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!enemy)
            {
                this.transform.position = enemies[i].transform.position;
                enemy = true;
                choice = i - 3;
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

    private void OnEnable()
    {
        i = enemies.FindIndex(x => x.activeInHierarchy == true);

        this.transform.position = enemies[i].transform.position;
    }
}
