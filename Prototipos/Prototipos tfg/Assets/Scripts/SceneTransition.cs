using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public GameObject destiny;
    public string escena;
    

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(escena.Length==0)
        {
            collider.gameObject.transform.position = destiny.transform.position;
        }
        else
        {
            collider.gameObject.transform.position = destiny.transform.position;
            SceneManager.LoadScene(escena);
        }


    }

}
