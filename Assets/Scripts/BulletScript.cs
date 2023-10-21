using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;

    [SerializeField] Rigidbody2D rb;

    
    public void Shoot(float dir)
    {
        rb.velocity = new Vector2(dir * speed,rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
            Debug.Log("Enemy Hited", this);
            Reset();
        }
        else
        {
            Reset();
        }
    }
    public void Reset()
    {
        //ObjectPool.Instance.AddtoQueue(this.gameObject);
        this.gameObject.SetActive(false);
    }
    public float getLifeTime()
    {
        return lifeTime;
    }
}
