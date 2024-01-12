using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalancingPlatform : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    private Quaternion initialPosition;
    [SerializeField] private bool reverseTiltDirection = false;
    private bool playerOnCube = false;
    private Transform player;

    private void Start()
    {
        initialPosition = transform.rotation;
    }

    void Update()
    {
        if (playerOnCube)
        {
            RotateCube();
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, initialPosition, rotationSpeed * Time.deltaTime);
        }
    }

    void RotateCube()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        if(reverseTiltDirection == true)
        {
            angle = -angle;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnCube = true;
            player = collision.transform;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnCube = false;
            player = null;
        }
    }
}
