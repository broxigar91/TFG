﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;
    Rigidbody2D playerBody;
    Animator anim;
    public RPGTalk rpgtalk;
    string touching;

    // Use this for initialization
    void Awake () {

        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {


       if(GameManager.instance.state == GameState.MAP)
       {

            //se utiliza el GetAxisRaw en vez del GetAxis porque nos da directamente 0 o 1 en el eje indicado mientras que con el otro va aumentando de valor
            Vector2 move_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (move_vector != Vector2.zero)
            {
                anim.SetBool("is_walking", true);
                anim.SetFloat("input_x", move_vector.x);
                anim.SetFloat("input_y", move_vector.y);
            }
            else
            {
                anim.SetBool("is_walking", false);
            }

            playerBody.MovePosition(playerBody.position + move_vector * Time.deltaTime);

        }

    }


}
