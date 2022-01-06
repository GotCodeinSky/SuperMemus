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
        else if (collision.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Hi Zombie");
            var rigidbd2 = collision.gameObject.GetComponent<Rigidbody2D>();
            var enemyTouch =  Physics2D.Raycast(transform.position, Vector2.down);
            if (enemyTouch.collider == null) return;
            rigidbd2.AddForce(Vector2.up * 2000);
            rigidbd2.AddForce(Vector2.right * 1450);
            rigidbd2.gravityScale = 20;
            rigidbd2.freezeRotation = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<EnemyMoving>().enabled = false;
            
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