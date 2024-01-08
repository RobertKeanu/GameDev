using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 platformPreviousPosition;
    private Transform player;
    private bool playerOnPlatform = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            platformPreviousPosition = transform.position;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    void FixedUpdate()
    {
        if (playerOnPlatform)
        {
            Vector3 platformMovement = transform.position - platformPreviousPosition;
            player.position += platformMovement;
            platformPreviousPosition = transform.position;
        }
    }
}