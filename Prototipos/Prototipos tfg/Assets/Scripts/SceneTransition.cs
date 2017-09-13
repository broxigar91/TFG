using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransition : MonoBehaviour {

    public GameObject destiny;
    public string escena;
    public int zone,encRate;


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
            GameManager.instance.zona_actual = zone;
            GameManager.instance.encounter_chance = encRate;


            SceneManager.LoadScene(escena);
        }
    }

    public IEnumerator ChangeScene()
    {

        FadeManager fm = GameObject.Find("Fader").GetComponent<FadeManager>();


        yield return StartCoroutine(fm.FadeToBlack());

        GameManager.instance.zona_actual = zone;
        GameManager.instance.encounter_chance = encRate;


        SceneManager.LoadScene(escena);
    }
}
