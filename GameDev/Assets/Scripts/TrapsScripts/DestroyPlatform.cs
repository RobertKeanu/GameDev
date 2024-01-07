using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private void Start()
    {
        GameObject door = GameObject.FindWithTag("Destroy");
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Plate")
        {
            Destroy(GameObject.FindWithTag("Destroy"), 3f);
            GameObject.FindWithTag("Player").transform.position = new Vector3(258.59f, 50.15f, 290.76f);
        }
    }   
}
