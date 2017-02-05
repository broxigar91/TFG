using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public Vector2 PlayerPosition;

    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {
    }

	// Update is called once per frame
	void Update () {
		
	}
}
