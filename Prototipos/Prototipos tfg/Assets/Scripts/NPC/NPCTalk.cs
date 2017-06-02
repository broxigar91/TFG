using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour {

    public RPGTalk rpgtalk;
    public int start, end;
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        rpgtalk.callbackScript = this;
        rpgtalk.lineToStart = start;
        rpgtalk.lineToBreak = end;
        rpgtalk.callbackFunction = "endTalking";
    }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.state = GameState.TALKING;
            rpgtalk.NewTalk();
        }
    }

    public void endTalking()
    {
        GameManager.instance.state = GameState.MAP;
    }
}
