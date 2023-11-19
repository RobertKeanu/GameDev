using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement")] public float speed;
    //Variables for setting the speed of the player/drag when the player is on the ground
    public float groundDrag;

    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;
    private bool _grounded;
    //The LayerMask checks what is considered as "ground" when checking for collisions
    public Transform orientation;

    private float _horizontalInput;
    [Header("Keybinds")] public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;
    //Different variables for setting the force of the jump in editor
    private float _verticalInput;
    private BoxCollider _boxCollider;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    private bool _wallFront;
    private bool _wallFront2;
    private bool _wallFront3;
    private bool _wallFront4;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        readyToJump = true;
        //In the start function we are getting a reference to the rigidbody component attached to the game object
        //We are setting the freezeRotation variable to true so that the player cannot rotate while moving
    }
    private void OnTriggerEnter(Collider other)
    {
            _grounded = true;
            Debug.Log("grounded");
    }
    private void OnTriggerExit(Collider other)
    {
            _grounded = false;
            Debug.Log("not grounded");
    }
    private void Update()
    {
        //grounded will return true if the raycast finds the collider of the ground (we check that by using the layermask created)
        PlInput();
        SpeedControl();
        if (_grounded)
        {
            _rigidbody.drag = groundDrag;
        }
        else
        {
            _rigidbody.drag = 0;
        }
        //We use drag to slow down the movement of the player while on the ground
    }   
    private void PlInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && _grounded && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump) , jumpCooldown);
            //Debug.Log("AM sarit");
        }
        //We check if the space button was pressed, if the player is on the ground and if the player can jump and based
        //on that we set the variable to false and we reset it after the cooldown of the jump is over
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
        _wallFront = Physics.Raycast(transform.position, orientation.forward,  playerHeight + 2.0f);
        _wallFront2 = Physics.Raycast(transform.position, Vector3.back,  playerHeight + 2.0f);
        _wallFront3 = Physics.Raycast(transform.position, Vector3.right,  playerHeight + 2.0f);
        _wallFront4 = Physics.Raycast(transform.position, Vector3.left,  playerHeight + 2.0f);

        if(_grounded) 
            _rigidbody.AddForce(_moveDirection.normalized * speed * 10f, ForceMode.Force);
        //We check if the player is on the ground and we apply a continuous force to the game object 
        else if (!_grounded)
        {

            if (_wallFront && _wallFront2 && _wallFront3 && _wallFront4)
            {
                _rigidbody.AddForce(_moveDirection.normalized*speed*10f*0, ForceMode.Force);
            }
            else if(!_wallFront && !_wallFront2 && !_wallFront3 && !_wallFront4)
                _rigidbody.AddForce(_moveDirection.normalized*speed*10f*airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatLevel = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        if (flatLevel.magnitude > speed) {
            //If the player's speed exceeds the limit, set it to the maximum speed.
            _rigidbody.velocity = new Vector3(flatLevel.normalized.x * speed, _rigidbody.velocity.y, flatLevel.normalized.z * speed);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        //We reset the velocity for y axis so that the jump is consistent and always jump the same height
        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        //We apply the force in the upward direction using the forcemode.impulse so that the force is applied only once
    }

    private void ResetJump()
    {
        readyToJump = true;
        //Function to reset the variable when the cooldown of the jump is over  
    }
}
