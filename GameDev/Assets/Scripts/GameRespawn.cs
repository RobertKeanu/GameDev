using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    [SerializeField]
    private float threshold;
    private Vector3 lastCheckpoint;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        lastCheckpoint = playerTransform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = lastCheckpoint;
        }
    }
}
