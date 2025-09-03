//
// this code are created by ChatGPT
//
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MarblePlayer : MonoBehaviour
{
    public float moveForce = 10f;   // Strength of push when moving
    public float maxSpeed = 20f;    // Clamp max speed
    public float jumpForce = 5f;    // Jump force
    public Transform cameraTransform; // To make movement relative to camera

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Jump input
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Get input (WASD)
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        // Camera-relative movement
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0f;  // Ignore tilt
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * v + right * h).normalized;

        // Apply rolling force
        rb.AddForce(moveDir * moveForce, ForceMode.Force);

        // Clamp velocity (optional for smoother control)
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Simple ground check (touching something beneath)
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
