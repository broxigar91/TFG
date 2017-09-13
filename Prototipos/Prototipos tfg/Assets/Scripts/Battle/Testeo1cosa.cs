using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeo1cosa : MonoBehaviour {


    private List<int> numeros;
    public int o, d;


	// Use this for initialization
	void Start () {
        numeros = new List<int>();
        numeros.Add(1);
        numeros.Add(2);
        numeros.Add(3);
        numeros.Add(4);
        numeros.Add(5);
        numeros.Add(6);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void intercambio()
    {
        numeros.ForEach(print);


        int aux = numeros[o];
        numeros[o] = numeros[d];
        numeros[d] = aux;

        numeros.ForEach(print);
    }

    void print(int i)
    {
        Debug.Log(i);
    }
}
