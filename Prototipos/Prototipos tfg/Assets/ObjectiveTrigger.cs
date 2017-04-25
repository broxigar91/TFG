using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour {

    public int objectiveId;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.instance.gameObject.GetComponent<ObjectiveDBController>().complete(objectiveId);
    }
}
