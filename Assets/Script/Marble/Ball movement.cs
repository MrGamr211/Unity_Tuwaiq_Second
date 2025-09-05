using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MarblePlayer : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public float maxSpeed = 10f;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float coyoteTime = 0.196f;   // "Mercy jump" window
    public float jumpCooldown = 0.264f; // Delay before another jump

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckDistance = 0.22f;
    public LayerMask groundLayer;

    [Header("Camera")]
    public Transform cameraTransform;

    private Rigidbody rb;
    private bool isGrounded;
    private bool jumpReady = true;
    private float coyoteTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleGroundCheck();
    }

    // -------------------------------
    // Movement
    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Camera-relative input
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * v + right * h).normalized;

        rb.AddForce(moveDir * moveForce, ForceMode.Force);

        // Clamp speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    // -------------------------------
    // Ground Check + Coyote Time
    void HandleGroundCheck()
    {
        bool groundedNow = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector3.down * groundCheckDistance, groundedNow ? Color.green : Color.red);

        if (groundedNow)
        {
            isGrounded = true;
            coyoteTimer = coyoteTime; // reset mercy jump
        }
        else
        {
            isGrounded = false;
            coyoteTimer -= Time.fixedDeltaTime;
        }
    }

    // -------------------------------
    // Jump Input
    void HandleJumpInput()
    {
        if (Input.GetKey(KeyCode.Space) && CanJump())
        {
            DoJump();
        }
    }

    bool CanJump()
    {
        return jumpReady && (isGrounded || coyoteTimer > 0f);
    }

    void DoJump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // reset vertical
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump!");

        jumpReady = false;
        StartCoroutine(JumpCooldown());
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        jumpReady = true;
    }
}
