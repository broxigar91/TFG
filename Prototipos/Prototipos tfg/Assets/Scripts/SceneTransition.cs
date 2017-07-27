using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public GameObject destiny;
    public string escena;
    public int zone;


    public IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (escena.Length == 0)
        {
            collider.gameObject.transform.position = destiny.transform.position;
        }
        else
        {

            FadeManager fm = GameObject.Find("Fader").GetComponent<FadeManager>();


            yield return StartCoroutine(fm.FadeToBlack());

            collider.gameObject.transform.position = destiny.transform.position;
            SceneManager.LoadScene(escena);
            GameManager.instance.zona_actual = zone;
        }

    }

}
