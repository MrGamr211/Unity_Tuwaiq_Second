using UnityEngine;

public class Attack : MonoBehaviour
{
    public health_sys Health_Sys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Damege"))
        {
            Health_Sys.TakeDMG(10);
            Debug.Log(Health_Sys.health);
        }
        if (other.gameObject.CompareTag("Heal"))
        {
            Health_Sys.TakeHeal(10);
            Debug.Log(Health_Sys.health);
        }
    }
}
