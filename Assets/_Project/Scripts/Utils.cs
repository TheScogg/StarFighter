using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{


    public static void MakePickup(Transform transform)
    {
        // Remove children from object, and Parent under --PICKUPS--
        foreach (Transform child in transform)
        {
            // places children on top of each other, in middle of explosion 
            child.transform.parent = GameObject.Find("--PICKUPS--").transform;
            child.transform.position = transform.position;

            // Calls rigidbodys for individual pieces of rock
            Rigidbody childRb = child.gameObject.AddComponent<Rigidbody>();
            childRb.isKinematic = false;
            childRb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;
            childRb.drag = 5;
            childRb.angularDrag = 1;
            childRb.useGravity = false;

            child.GetComponent<SphereCollider>().enabled = true;
            child.gameObject.AddComponent<Pickup>();


        }
    }




    }


