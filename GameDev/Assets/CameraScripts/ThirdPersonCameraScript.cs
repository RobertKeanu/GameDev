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
        private float _horizontalInput;
        private float _verticalInput;
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
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
            // Calculate the input direction based on camera orientation.
            Vector3 inputDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

            // If there's player input, adjust the player's forward direction directly.
            if (inputDirection != Vector3.zero)
            {
                playerObject.forward = inputDirection.normalized;
            }
        }
    }
}