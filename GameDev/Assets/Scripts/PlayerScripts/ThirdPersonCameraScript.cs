using UnityEngine;

namespace CameraScripts
{
    public class ThirdPersonCameraScript : MonoBehaviour
    {
        [Header("References")]
        public Transform orientation;
        public Transform player;
        public Transform playerObject;
        public Rigidbody rigidBody;
        public float cameraSpeed;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //We lock the cursor in the middle of the screen and make it invisible
        }

        void Update()
        {
            // Calculate the camera's orientation based on player input.

            // Determine the direction from the camera to the player.
            Vector3 direction = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            // Set the camera's forward direction to match the normalized direction.
            orientation.forward = direction.normalized;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            // Calculate the input direction based on camera orientation.
            Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            // If there's player input, adjust the player's forward direction directly.
            if (inputDirection != Vector3.zero)
            {
                playerObject.forward = Vector3.Slerp(playerObject.forward, inputDirection.normalized,
                    Time.deltaTime * cameraSpeed);
            }
        }
    }
}