using UnityEngine;
using UnityEngine.UIElements;

public class MarbleMovement : MonoBehaviour
{
    public float RotationSpeed = 5;
    private Rigidbody RbPlayer;
    private Vector3 MovementInput;
    void Start()
    {
        RbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        RbPlayer.linearVelocity = new Vector3(Horizontal * RotationSpeed, RbPlayer.transform.rotation.x);
        float Vertical = Input.GetAxisRaw("Vertical");
        RbPlayer.linearVelocity = new Vector3(Vertical * RotationSpeed, RbPlayer.transform.rotation.y);
    }
}
