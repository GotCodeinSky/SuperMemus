using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    // PlayerMove - PascalCase
    // playerMove - camelCase
    // player_move - snake-case/underscore_case
    // player-move - kebab-case

    //int 5
    //float 5.6f
    //string "Privet"
    //bool true false

    [Header("Параметры Кирилла")]
    [SerializeField] protected int PlayerSpeed = 50;
    [SerializeField] protected float PlayerJump = 2565.5f;
    private float moveX;
    [SerializeField] protected bool IsGrounded;
    void Start()
    {
        Debug.Log("Hello world");
    }

    // Update is called once per frame
    void Update()
    {    
       PlayerMove();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    //My methods
   void PlayerMove()
   {
       moveX = Input.GetAxis("Horizontal");
       if (Input.GetButtonDown("Jump") && IsGrounded) 
       {
            Jump();
       } 
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
   } 

    void Jump()
    {
       GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJump);
       IsGrounded = false;
    }
   
} 