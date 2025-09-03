using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Rigidbody rb;
    public int Speed = 10;

    public Animator anim; // define the selected Animatior


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        anim.SetFloat("H", x); //read float (Input)


        anim.SetFloat("V", z); //read float (Input)

        Vector3 Move = new Vector3(x, 0f, z);
        rb.linearVelocity =  Move * Speed * Time.deltaTime * 1000;

    }
}
