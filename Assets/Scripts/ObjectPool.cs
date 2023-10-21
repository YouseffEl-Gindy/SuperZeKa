using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool Instance;
    List<GameObject> poolList = new List<GameObject>();

    [SerializeField] int size;
    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        for(int i =0 ; i < size; ++i)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            poolList.Add(obj);
        }
        

    }

   public GameObject getBullet()
    {
        for(int i = 0 ; i < poolList.Count; ++i)
        {
            GameObject obj = poolList[i];
            if(!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
    
}
