using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1_2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveForce = 10f;
    public Vector2 playerInput;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float coyoteTime = 0.196f;
    public float jumpCooldown = 0.264f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckDistance = 0.22f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpReady = true;
    private float coyoteTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    void HandleMovement()
    {
        float h = playerInput.x; // Left/Right from A/D
        // float v = playerInput.y; // if you later want Up/Down (W/S)

        // Physics-based movement
        rb.AddForce(new Vector2(h * moveForce, 0f));

        float maxSpeed = moveForce; 
        if (Mathf.Abs(rb.linearVelocity.x) > maxSpeed)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeed, rb.linearVelocity.y);
        }

        if (h != 0)
            transform.localScale = new Vector3(Mathf.Sign(h), 1f, 1f);
    }



    void HandleGroundCheck()
    {
        bool groundedNow = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckDistance, groundedNow ? Color.green : Color.red);

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

    void HandleJumpInput()
    {
        if (playerInput.y >= 0.7071 && CanJump())
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
        // Reset vertical before jumping (arcade feel)
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Jump! P1");

        jumpReady = false;
        StartCoroutine(JumpCooldown());
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        jumpReady = true;
    }


    public void Player1Input(InputAction.CallbackContext context)
    {
        playerInput = context.ReadValue<Vector2>();
    }
}
