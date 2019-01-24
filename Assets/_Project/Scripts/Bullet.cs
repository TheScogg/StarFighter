using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    public ObjectPool objectPool;
    public Vector3 direction;

    public float bulletSpeed = 20f;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //rb.MovePosition(transform.position + (direction * bulletSpeed * Time.deltaTime));
        rb.AddForce((direction * bulletSpeed * Time.deltaTime), ForceMode.Impulse);

        if (timer <= 0)
        {
            GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<ObjectPool>().ReturnObjectToPool(gameObject);
        }
    }


    private void OnCollisionEnter(Collision other)
    {

        GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<ObjectPool>().ReturnObjectToPool(gameObject);

    }


}
