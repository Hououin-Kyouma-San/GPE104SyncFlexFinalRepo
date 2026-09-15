using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // RigidBody component, movement vector, and player orientation
    Rigidbody rigidBody;
    Vector3 moveDirection;
    public Transform orientation;

    // Vertical and horizontal axis points inputs
    private float horizontalInput;
    private float verticalInput;

    // Public move speed and jump force values
    public float moveSpeed;
    public float jumpForce;

    // Jump check boolean, player can only jump if enabled
    public bool jumpCheck;

    // Start, Update, and FixedUpdate methods
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
        rigidBody.linearDamping = rigidBody.linearDamping = 5.0f;
        jumpCheck = true;
    }
    private void Update()
    {
        PlayerInput();
        MovementClamp();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Player input method, defines axis points for inputs and jump function
    private void PlayerInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && jumpCheck != false)
        {
            Jump();
        }
    }

    // Player movement method
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rigidBody.AddForce(moveDirection.normalized * moveSpeed * 10.0f, ForceMode.Force);
    }

    // Movement clamping method
    private void MovementClamp()
    {
        Vector3 CurrentVelocity = new Vector3(rigidBody.linearVelocity.x, 0f, rigidBody.linearVelocity.z);
        if (CurrentVelocity.magnitude > moveSpeed)
        {
            Vector3 ClampedVelocity = CurrentVelocity.normalized * moveSpeed;
            rigidBody.linearVelocity = new Vector3(ClampedVelocity.x, rigidBody.linearVelocity.y, ClampedVelocity.z);
        }
    }

    // Player jump method
    private void Jump()
    {
        rigidBody.linearVelocity = new Vector3(rigidBody.linearVelocity.x, 0.0f, rigidBody.linearVelocity.z);
        rigidBody.linearDamping = rigidBody.linearDamping = 0.0f;
        rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        jumpCheck = false;
    }

    // Disables the jump check boolean on collision
    public void OnCollisionEnter(Collision collision)
    {
        if (jumpCheck != true)
        {
            rigidBody.linearDamping = rigidBody.linearDamping = 5.0f;
            jumpCheck = true;
        }
    }
}