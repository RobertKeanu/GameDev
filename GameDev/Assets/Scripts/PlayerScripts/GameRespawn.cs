using Unity.VisualScripting;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    [SerializeField]
    private float threshold = 17.0f;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            KillFunction();
        }
        else if (other.CompareTag("SpawnPoint"))
        {
            lastCheckpoint = transform.position;
            Destroy(other.gameObject);
        }
    }

    public void KillFunction()
    {
        transform.position = lastCheckpoint;
    }
}
