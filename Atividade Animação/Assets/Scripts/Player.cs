using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public float pulo = 100;
    public bool noChao;
    private Rigidbody2D rig;
    private Animator anim;
    

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!noChao && collision.gameObject.tag == "Chão")
        {
            noChao = true;
            anim.SetBool("EstaPulando",false);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = Vector2.right * speed;
            anim.SetBool("EstaCorrendo",true);
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = Vector2.left * speed;
            anim.SetBool("EstaCorrendo",true);
            transform.eulerAngles = new Vector2(0f, 180f);
        }
        else
        {
            anim.SetBool("EstaCorrendo",false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rig.AddForce(transform.up * pulo, ForceMode2D.Impulse);
            anim.SetBool("EstaPulando",true);
            noChao = false;
            anim.SetBool("EstaPulando",false);
        }
    }
}
