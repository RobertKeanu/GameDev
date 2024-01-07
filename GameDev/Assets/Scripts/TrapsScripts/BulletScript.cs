using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulltScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _speed;
        Destroy(gameObject, 4f);
    }

    //Trebuie modificat in checkpoint!!!
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject.FindWithTag("Player").transform.position = new Vector3(258.59f, 50.15f, 290.76f);
        }
    }
}
