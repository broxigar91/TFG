using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;
    public List<Enemy> enemies;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
		for(int i=0;i<gameObject.transform.childCount;i++)
        {
            enemies.Add(gameObject.transform.GetChild(i).GetComponent<Enemy>());
        }
	}
	
    public List<Enemy> getByZone(int z)
    {
        return enemies.FindAll(x => x.zone == z);
    }

    public Sprite getSprite(int i)
    {
        return gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite;
    }

    public Animator getAnimator(int i)
    {
        return gameObject.transform.GetChild(i).GetComponent<Animator>();
    }

    public List<Enemy> toBattle(int z)
    {
        List<Enemy> aux = getByZone(z);
        List<Enemy> en = new List<Enemy>();
        int rn;

        while (en.Count < 3)
        {
            rn = Random.Range(0, aux.Count);
            en.Add(aux[rn]);
        }

        return en;
    }
}
