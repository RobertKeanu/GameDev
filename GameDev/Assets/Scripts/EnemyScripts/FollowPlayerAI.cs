using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initialPosition;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float attackDistance = 10f;
    float distanceToPlayer;

    void Start()
    {
        Invoke("SaveInitialPosition", 1.0f);
    }

    void SaveInitialPosition()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, targetObject.position);

        if(distanceToPlayer <= attackDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObject.position, moveSpeed * Time.deltaTime);
            transform.LookAt(targetObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
            transform.LookAt(initialPosition);
        }
    }
}
