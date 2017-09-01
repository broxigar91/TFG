using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeManager : MonoBehaviour {


    private bool isFading;
    private float fadeSpeed;
    public Image img;


    void Awake()
    {
        DontDestroyOnLoad(this);
        
    }

    void Start()
    {
        isFading = false;
        fadeSpeed = 0.9f;
    }



    public IEnumerator FadeToBlack()
    {
        isFading = true;

        while(isFading)
        {
            img.color = Color.Lerp(img.color, Color.black, fadeSpeed * Time.deltaTime);
            if(img.color.a >=0.99f)
            {
                isFading = false;
            }
            yield return null;
        }
        StartCoroutine(FadeToClear());
    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        yield return StartCoroutine(Wait());

        while (isFading)
        {
            Debug.Log("asaaasddeert");
            img.color = Color.Lerp(img.color, Color.clear, fadeSpeed * Time.deltaTime);
            if (img.color.a <= 0.01f)
            {
                isFading = false;
            }
            yield return null;
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
