using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Time5());
    }

    IEnumerator Time5()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Congrats, you waited 5 Seconds!");
    }

}
