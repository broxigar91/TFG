using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public GameObject destiny;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.transform.position = destiny.transform.position;
    }
}
