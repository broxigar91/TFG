using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeManager : MonoBehaviour {


    private bool isFading;
    public float fadeSpeed;
    public Image img;


    void Awake()
    {
        DontDestroyOnLoad(this);
        
    }

    void Start()
    {
        isFading = false;
        img = this.transform.Find("Transition").GetComponent<Image>();
        fadeSpeed = 0.8f;
    }



    public IEnumerator FadeToBlack()
    {
        isFading = true;

        while(isFading)
        {
            img.color = Color.Lerp(img.color, Color.black, fadeSpeed * Time.deltaTime);
            if(img.color.a >=0.95f)
            {
                isFading = false;
            }
            yield return null;
        }
    }

    public IEnumerator FadeToClear()
    {
        isFading = true;

        while (isFading)
        {
            Debug.Log("asaaasddeert");
            img.color = Color.Lerp(img.color, Color.clear, fadeSpeed * Time.deltaTime);
            if (img.color.a < 0.05f)
            {
                isFading = false;
            }
            yield return null;
        }
    }

    public void EndScene()
    {
        FadeToClear();
    }
}
