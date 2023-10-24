using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    #region
    [SerializeField] int maxHits;
    [SerializeField] float intervalBetweenHits;

    float currentHits;
    float timeToNextHit;
    bool canHit;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        currentHits = maxHits;
        canHit = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(canHit && collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeHit();
            TakeDamage();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("EnemyHealth :" + currentHits, this);
        if (!canHit)
        {
            timeToNextHit -= Time.deltaTime;
            if(timeToNextHit <= 0)
            {
                canHit=true;
            }
        }
    }
    public void TakeDamage()
    {
        currentHits--;
        AudioManager.Instance.PlaySFX("BulletHit");
        if (currentHits <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            canHit = false;
            timeToNextHit = intervalBetweenHits;
        }
    }
    public float GetHealthPercentage()
    {
        return (float)currentHits / (float)maxHits;
    }
}
