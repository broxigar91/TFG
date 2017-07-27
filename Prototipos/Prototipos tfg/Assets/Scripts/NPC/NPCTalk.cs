using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour {

    public RPGTalk rpgtalk;
    public int start, end;
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(rpgtalk == null);
        rpgtalk.lineToStart = start;
        rpgtalk.lineToBreak = end;

        if(this.tag != "Vendor")
        {
            rpgtalk.callbackScript = this;
            rpgtalk.callbackFunction = "endTalking";
            
        }
        else
        {
            rpgtalk.callbackScript = gameObject.GetComponent<Vendor>();
            rpgtalk.callbackFunction = "displayStore";
        }
    }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            rpgtalk.NewTalk();
            GameManager.instance.state = GameState.TALKING;
            
        }
    }

    public void endTalking()
    {
        GameManager.instance.state = GameState.MAP;
    }
}
