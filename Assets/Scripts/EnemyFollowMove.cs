using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float range;

    [SerializeField] Transform player;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;



    enum EnemyState
    {
        Idle,
        Run
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyState state = EnemyState.Idle;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= range)
        {
            state = EnemyState.Run;
            Vector3 direction = player.position - transform.position;
            if(direction.x <0)
            {
                spriteRenderer.flipX = true;
            }
            else if(direction.x > 0) 
            {
                spriteRenderer.flipX = false;
            }

            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        animator.SetInteger("State", (int)state);
    }
}