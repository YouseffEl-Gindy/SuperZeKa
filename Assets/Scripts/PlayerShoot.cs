using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Fire();
            AudioManager.Instance.PlaySFX("Shoot");
        }
    }
    void Fire()
    {
        GameObject bullet = ObjectPool.Instance.getBullet();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = shootPoint.position;
            float dir = PlayerMove1.Instance.getDirection();
            bullet.GetComponent<BulletScript>().Shoot(dir);
            StartCoroutine(DeactiveBullet(bullet));
        }
        
        
    }
    IEnumerator DeactiveBullet(GameObject bullet)
    {
        float lifeTime = bullet.GetComponent<BulletScript>().getLifeTime();
        yield return new WaitForSeconds(lifeTime);
        bullet.gameObject.SetActive(false);
    }
}
