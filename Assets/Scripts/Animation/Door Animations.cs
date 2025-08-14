using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    public Animator anim;
    public bool open;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Open", true);
        }
    }




}
