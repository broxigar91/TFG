﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D playerBody;
    Animator anim;


	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //se utiliza el GetAxisRaw en vez del GetAxis porque nos da directamente 0 o 1 en el eje indicado mientras que con el otro va aumentando de valor
        Vector2 move_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(move_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_X", move_vector.x);
            anim.SetFloat("input_Y", move_vector.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        playerBody.MovePosition(playerBody.position + move_vector * Time.deltaTime);
	}
}
