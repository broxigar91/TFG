using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ItemEvent : MonoBehaviour, IPointerClickHandler {

    public int pos;
    public int id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button.Equals(PointerEventData.InputButton.Right))
        {

        }
    }
}
