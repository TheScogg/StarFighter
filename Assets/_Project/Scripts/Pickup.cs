using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();


        StartCoroutine("Blink");

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator Blink()
    {
        yield return null;
    }


}
