﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public bool isOnGround = false;
    public AudioSource jump;
    int jumpcount = 1;
    public int jumptest = 1;
    Animator anim;
   // public static int hp;
   // public static int kills;
   // public Text health;
   // public Text Kill;

    void Start()
    {
        anim = GetComponent<Animator>();
        //hp = 100;
        //health.text = "HEALTH: " + hp;
        //kills = 0;
    }
    void Update()
    {
        //health.text = "HEALTH: " + hp;
        //Kill.text = "" + kills;
        float movex = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = movex * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = velocity;
        if (Input.GetButtonDown("Jump") && jumptest > 0)
        {
            Jump();
        }

        if (velocity.x > 0)
        {
            Quaternion transfer = GetComponent<Transform>().rotation;
            transfer.y = 0;
            GetComponent<Transform>().rotation = transfer;
        }
        if (velocity.x < 0)
        {
            Quaternion transfer = GetComponent<Transform>().rotation;
            transfer.y = -180;
            GetComponent<Transform>().rotation = transfer;
        }
        //if (hp <= 0)
       // {
        //    anim.SetTrigger("death");
        //}

    }
    public void Jump()
    {
        if (jumptest == jumpcount)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100 * jumpHeight));
            jumptest -= 1;
        }
        else
        {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = 0;
            GetComponent<Rigidbody2D>().velocity = velocity;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 75 * jumpHeight));
            jumptest -= 1;
        }
        jump.pitch = 1;
        float pitch = jump.pitch;
        float sounddiffer = Random.Range(-.5f, .5f);
        pitch = pitch + sounddiffer;
        jump.pitch = pitch;
        jump.Play();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 0)
        {
            isOnGround = true;

            jumptest = jumpcount;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "enemy")
       // {
          //  if (hp > -1)
          //  {
            //    hp = hp - 1;
           // }


       // }
        if (collision.gameObject.layer == 0)
        {
            isOnGround = true;

            jumptest = jumpcount;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 0)
        {
            isOnGround = false;

            jumptest -= 1;
        }
    }
    void SceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Deathanim()
    {

        anim.SetTrigger("death");
    }
}
