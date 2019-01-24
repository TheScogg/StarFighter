using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Renderer _rend;
    private Rigidbody _rb;


    // Explosion effect for when you destory asteroid
    public GameObject explosionFX;
    private IEnumerator coroutine;


    public float health = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
        SetColor();
    }

    private void SetColor()
    {
        Renderer _rend;
        Color randColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f);



        foreach (Transform child in transform) {
            _rend = child.GetComponent<Renderer>();
            //_rend.material = new Material(Shader.Find("Toon/Lit Outline"));
            _rend.material.SetColor("_Color", randColor);

        }
    }

    private void InitVariables()
    {
        _rend = GetComponent<MeshRenderer>();
        _rb = GetComponent<Rigidbody>();

    }

    private void InstantiateExplosion()
    {
        Utils.MakePickup(transform);

        GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);



        _rb.AddExplosionForce(.5f, transform.position, 1f);

        // Put behind coroutine so item has time to explode outwards and change parent
        coroutine = Destroy(.1f);
        StartCoroutine(coroutine);

    }

    IEnumerator Destroy(float timer)
    {

        yield return new WaitForSeconds(timer);
        Destroy(gameObject);

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 500 / Vector3.Distance(Vector3.zero, transform.position) * Time.deltaTime);

        if (health <= 0)
        {
            InstantiateExplosion();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Turn this into a static util method
        // Util.GetDamage(collision.rigidbody.velocity.magnitude * collision.rigidbody.mass)
        // public static float GetDamage(float magnitude, float mass) { return magnitude * mass * dmgMult; }

        health -= (collision.rigidbody.mass * collision.relativeVelocity.magnitude);
        
    }
}
