using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Material mat = Resources.Load("green", typeof(Material)) as Material;
        if (other.gameObject.name == "SpawnPoint")
            gameObject.GetComponent<Renderer>().material = mat;
    }
}
