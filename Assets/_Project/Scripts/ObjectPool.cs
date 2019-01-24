using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private Queue<GameObject> pool;
    public int poolSize;


    public GameObject testPrefab;

    private void Start()
    {
        //InitializePool(20, testPrefab);
    }

    public void InitializePool(int poolSize, GameObject prefab)
    {
        print(transform.name);

        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);

            pool.Enqueue(obj);
            obj.transform.parent = transform;
            obj.SetActive(false);

        }
    }

    public GameObject GetObjectFromPool(Vector3 pos, Quaternion rot, Vector3 direction)
    {
        GameObject newBullet = pool.Dequeue();

        newBullet.transform.position = pos;
        newBullet.transform.rotation = rot;
        newBullet.SetActive(true);
        newBullet.GetComponent<Bullet>().direction = direction;
        return newBullet;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        pool.Enqueue(obj);
        obj.SetActive(false);

    }
}
