using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    private Asteroid asteroid;
    public int numAsteroids;

    private List<Color> colorsArray;

    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitVariables()
    {
        colorsArray = new List<Color>();
        _rb = GetComponent<Rigidbody>();
    }

    void SetColor()
    {
        foreach (Transform child in transform)
        {
            asteroid.GetComponent<Renderer>().material.SetColor("_BaseColor", colorsArray[Random.Range(0, colorsArray.Count - 1)]);
        }
    }

    void Spawn() {
        for (int i = 0; i < numAsteroids; i++) {
            asteroid = Instantiate(asteroidPrefab);
            asteroid.transform.position = new Vector3(Random.Range(-250, 250), 3, Random.Range(-250, 250));

            // Loops through child pieces and sets random color
            SetColor();
         }
     }

}

