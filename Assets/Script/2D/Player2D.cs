//
//
// this code are Created by ChatGPT
//
//

using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;

    // Ground check
    public Transform groundCheck;     // Empty GameObject below the player
    public float groundCheckDistance = 0.2f; 
    public LayerMask groundLayer;     // Set this in the Inspector
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement
        movementInput.x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2 (movementInput.x * moveSpeed, rb.linearVelocity.y);

        // Ground check raycast
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);

        // Debug line (so you can see the ray in Scene view)
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckDistance, Color.red);

        // Example: allow jump if grounded
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForceY(20f, ForceMode2D.Impulse);
            Debug.Log("space!");
        }
    }
}
