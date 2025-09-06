using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public Renderer buttonRenderer;    // assign in Inspector
    public Color pressedColor = Color.red;
    public Color defaultColor = Color.gray;

    private int playersOnButton = 0;

    void Start()
    {
        if (buttonRenderer == null)
            buttonRenderer = GetComponent<Renderer>();

        buttonRenderer.material.color = defaultColor;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersOnButton++;
            buttonRenderer.material.color = pressedColor;
            Debug.Log("Player stepped on the button!");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersOnButton--;

            if (playersOnButton <= 0)
            {
                buttonRenderer.material.color = defaultColor;
                Debug.Log("Button released!");
            }
        }
    }
}
