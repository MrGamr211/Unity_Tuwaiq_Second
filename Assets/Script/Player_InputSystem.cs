using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_InputSystem : MonoBehaviour
{
    public Vector2 move;
    public float speed;
    public bool jump;
    public bool sprint;
    public float jumpforce;

    public Rigidbody rb;


    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        sprint = context.action.triggered;
    }

    void Update()
    {
        //                  bool varible, (?) = if true, (:) = if false
        float currentSpeed = sprint ? speed * 2 : speed; // if sprint is true; speed * 2, else; speed.
        Vector3 playermove = new Vector3(move.x, 0, move.y); // Vector3(x, y, z), move are Vector2(x, y) (front/back, left,right)
        rb.linearVelocity = playermove * currentSpeed;
        
        if (jump) rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        
    }
}