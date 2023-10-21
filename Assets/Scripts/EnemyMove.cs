using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
  


    [SerializeField] float speed;
    [SerializeField] float directionChangeInterval;
     float timeUntilNextDirectionChange;
     float direction;




    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextDirectionChange = directionChangeInterval;
        direction = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        timeUntilNextDirectionChange -= Time.deltaTime;
        if (timeUntilNextDirectionChange < 0)
        {
            timeUntilNextDirectionChange = directionChangeInterval;
            direction = -direction;
            Flip();
        }
        Vector2 movement = new Vector2(direction * speed, rb.velocity.y);
        rb.velocity = movement;
        
       
    }
    public void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
    
}
