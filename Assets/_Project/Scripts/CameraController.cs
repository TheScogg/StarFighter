using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    private Camera cam;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        offset = cam.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = offset + player.transform.position;   
    }
}
