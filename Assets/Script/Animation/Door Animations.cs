using System.Collections;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    public Animator anim;
    public bool open;


    void Start()
    {
        StartCoroutine(Delay0());
    }

    IEnumerator Delay0() {
        yield return new WaitForSeconds(2);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Open", true);

        }
        
    }




}
