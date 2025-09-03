using UnityEngine;

public class health_sys : MonoBehaviour
{
    public float health;
    public float maxHalth = 100;
    void Start()
    {
        health = maxHalth;
    }

    public void TakeDMG(float DMG)
    {
        if (health < 0)
        {
            Die();
        }
    }
    public void TakeHeal(float heal)
    {
        health += heal;
    }
    void Die()
    {
        Destroy(gameObject); 
    }
}
