using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    public Slider slider;
    public float time;
    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        slider.value = time / 100;
        if (time == 0)
        {
            Debug.Log("Time = 0");
        }
    }
    IEnumerator Timer()
    {
        while (true)
        {
            
        yield return new WaitForSeconds(1);
        time--;
        }

    }
}
