using UnityEngine;

public class Shoting1 : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb.AddForce(Vector3.forward * 20);
    }


    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
