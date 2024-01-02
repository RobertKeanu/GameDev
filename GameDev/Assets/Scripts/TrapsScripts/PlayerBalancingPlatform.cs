using UnityEngine;

public class PlayerBalancingPlatform : MonoBehaviour
{
    public float tiltSpeed = 5f;
    public float returnSpeed = 2f;

    private bool isPlayerOnPlatform = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BalancingPlatform"))
        {
            isPlayerOnPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("BalancingPlatform"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private void Update()
    {
        if (isPlayerOnPlatform)
        {
            TiltPlatform();
        }
        else
        {
            ReturnToOriginalPosition();
        }
    }

    private void TiltPlatform()
    {
        // Get the player's position relative to the platform
        Vector3 playerLocalPosition = transform.InverseTransformPoint(transform.position);

        // Calculate the tilt angle based on the player's position on the platform
        float tiltAngle = Mathf.Atan2(playerLocalPosition.x, playerLocalPosition.z) * Mathf.Rad2Deg;

        // Apply rotation to the platform around its up axis
        transform.rotation = Quaternion.Euler(0f, 0f, -tiltAngle * tiltSpeed);
    }

    private void ReturnToOriginalPosition()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, returnSpeed * Time.deltaTime);
    }

}
