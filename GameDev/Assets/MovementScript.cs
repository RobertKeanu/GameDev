using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [Header("Movement")] public float speed;

    public float groundDrag;

    [Header("Ground Check")] public float playerHeight;
    public LayerMask whatIsGround;
    private bool _grounded;

    public Transform orientation;

    private float _horizontalInput;
    [Header("Keybinds")] public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        readyToJump = true;
    }

    private void PlInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log(readyToJump);
        if (Input.GetKey(jumpKey) && _grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump) , jumpCooldown);
            //Debug.Log("AM sarit");
        }
    }
    private void Update()
    {
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f,whatIsGround);
        SpeedControl();
        PlInput();
        //Debug.Log(_grounded);
        if (_grounded)
        {
            _rigidbody.drag = groundDrag;
        }
        else
        {
            _rigidbody.drag = 0;
        }
    }   

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;
        if(_grounded)
            _rigidbody.AddForce(_moveDirection.normalized * speed * 10f, ForceMode.Force);
        else if (!_grounded)
        {
            _rigidbody.AddForce(_moveDirection.normalized*speed*10f*airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatLevel = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        if (flatLevel.magnitude > speed)
        {
            Vector3 limitedVel = flatLevel.normalized * speed;
            _rigidbody.velocity = new Vector3(limitedVel.x, _rigidbody.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        _rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
