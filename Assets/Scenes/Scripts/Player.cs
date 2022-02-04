using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("Scenes/Level2");
        }
        if (col.gameObject.CompareTag("Coin"))
        {
            var rigidbody2d = col.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2d.AddForce(Vector2.up * 2800);
            rigidbody2d.AddForce(Vector2.right * 700);
            rigidbody2d.gravityScale = 2;
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            PlayerScore.CollectMoney();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
            GetComponent<Animator>().SetBool("IsJumping", false);
        }
        else if (collision.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Hi Zombie");
            var rigidbd2 = collision.gameObject.GetComponent<Rigidbody2D>();
            var hitDown =  Physics2D.Raycast(transform.position, Vector2.down);
            if (hitDown.collider == null) return;
            rigidbd2.AddForce(Vector2.up * 2000);
            rigidbd2.AddForce(Vector2.right * 1450);
            rigidbd2.gravityScale = 20;
            rigidbd2.freezeRotation = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<EnemyMoving>().enabled = false;
            
        }
        else if (collision.gameObject.CompareTag("DestroyBlocks"))
        {
            Debug.Log("Destroy It");
            var rigidbd = collision.gameObject.GetComponent<Rigidbody2D>();
            var direction = Random.value;
            Debug.Log(direction.ToString());
            var hitUp =  Physics2D.Raycast(transform.position, Vector2.up);
            if (hitUp.collider == null) return;
            rigidbd.AddForce(Vector2.up * 1400);
            if (direction > 0.5f)
            {
                rigidbd.AddForce(Vector2.left * 1450);
            }
            else
            {
               rigidbd.AddForce(Vector2.right * 1200);
            }
            rigidbd.gravityScale = 20;
            rigidbd.freezeRotation = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
        } 
    }

    //My methods
   void PlayerMove()
   {
       moveX = Input.GetAxis("Horizontal");
       GetComponent<Animator>().SetBool("IsRunning", moveX != 0);
       if (moveX < 0.0f)
       {
           GetComponent<SpriteRenderer>().flipX = true;
       } else if (moveX > 0.0f)
       {
           GetComponent<SpriteRenderer>().flipX = false;
       }
       if (Input.GetButtonDown("Jump") && IsGrounded)
       {
            Jump();
       } 
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * PlayerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

   } 

    void Jump()
    { 
        GetComponent<Animator>().SetBool("IsJumping", true); 
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * PlayerJump);
        IsGrounded = false;
    }
   
} 