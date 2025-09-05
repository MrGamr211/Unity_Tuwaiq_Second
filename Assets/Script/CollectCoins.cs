using Unity.VisualScripting;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    int CoinsCollected;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            // Destroy(gameObject); //Destroy self
            Destroy(collision.gameObject); // Destroy the collided
            CoinsCollected++;
            Debug.Log(CoinsCollected);
            //Destroy(collision.gameObject); Destroy the collided
            //return CoinsCollected;

        }
        // if (collision.gameObject.tag == "Coin")
        // {
        //     Destroy(collision.gameObject);
        //     CoinsCollected++;
        //     Debug.Log(CoinsCollected);
        //     // return CoinsCollected;

        // }
    }
}
