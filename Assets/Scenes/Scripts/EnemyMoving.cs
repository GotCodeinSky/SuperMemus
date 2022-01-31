using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int enemySpeed = 50;
    [SerializeField] protected int enemyDirection = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyDirection, 0) * enemySpeed;
        var enemyTouch =  Physics2D.Raycast(transform.position, new Vector2(enemyDirection, 0));
        if (enemyTouch.distance < 0.8f)
        {
             Flip();
             if (enemyTouch.collider.CompareTag("Player"))
             {
                 Destroy(enemyTouch.collider.gameObject);
                 PlayerHealth.Die();
             }
        }
    }

    private void Flip()
    {
        if (enemyDirection > 0)
        {
            enemyDirection = -1;
        } else
        {
            enemyDirection = 1;
        }
            
    }
    
    private void Flip2()
    {
        enemyDirection = enemyDirection > 0 ? -1 : 1;
    }
}
