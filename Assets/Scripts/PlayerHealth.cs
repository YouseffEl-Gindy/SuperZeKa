using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    [SerializeField] int maxHits;
    int currentHits;

    public delegate void OnPlayerHitDelegate();
    public event OnPlayerHitDelegate OnPlayerHit;



    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHits = maxHits;
    }

    // Update is called once per frame
    public void TakeHit()
    {
        currentHits--;
        AudioManager.Instance.PlaySFX("BulletHit");
        if(currentHits <= 0) 
        {
            Die();
        }
        else
        {
            OnPlayerHit?.Invoke();
        }
    }

    public float GetHealthPercentage()
    {
        return (float)currentHits / (float)maxHits;
    }
    public void Die()
    {
        // To be continued
        MenuManager.Instance.GameOver();
        GameObject.Destroy(gameObject);

    }
    
}
