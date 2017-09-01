using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCTalk : MonoBehaviour {

    public RPGTalk rpgtalk;
    public int start, end, objective;
    public bool vendor, boss;
    public bool contact;
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(rpgtalk == null);
        rpgtalk.lineToStart = start;
        rpgtalk.lineToBreak = end;


        if(vendor == true)
        {
            rpgtalk.callbackScript = gameObject.GetComponent<Vendor>();
            rpgtalk.callbackFunction = "displayStore";

            
        }
        else if(boss == true)
        {
            rpgtalk.callbackScript = this;
            rpgtalk.callbackFunction = "toBattle";

        }
        else
        {
            rpgtalk.callbackScript = this;
            rpgtalk.callbackFunction = "endTalking";
        }
        contact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contact = false;
    }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E) && contact==true)
        {
            rpgtalk.NewTalk();
            GameManager.instance.state = GameState.TALKING;
            if(objective!=-1)
                GameManager.instance.GetComponent<ObjectiveDBController>().complete(objective);
        }
    }

    public void endTalking()
    {
        GameManager.instance.state = GameState.MAP;
    }

    public void StartBattle()
    {
        GameManager.instance.enterBattle();
    }
}
