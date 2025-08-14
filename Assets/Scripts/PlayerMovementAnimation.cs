using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

    }
}
