using UnityEngine;

public class ResetCubes : MonoBehaviour
{
    private Vector3[] initialPositions;
    public Transform[] objectsToReset;

    void Start()
    {
        StoreInitialPositions();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player")) 
        {
            ResetObjectsToInitialPositions();
        }
    }

    void StoreInitialPositions()
    {
        initialPositions = new Vector3[objectsToReset.Length];

        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].position;
        }
    }

    void ResetObjectsToInitialPositions()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].position = initialPositions[i];
        }
    }
}
