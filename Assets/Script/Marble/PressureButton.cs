using UnityEngine;
using UnityEngine.Events; // <- needed for events

public class PressureButton : MonoBehaviour
{
    public Renderer buttonRenderer;
    public Color pressedColor = Color.red;
    public Color defaultColor = Color.gray;

    private int playersOnButton = 0;

    [Header("Events")]
    public UnityEvent onPressed;
    public UnityEvent onReleased;

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
            if (playersOnButton == 1) // only trigger once
                onPressed.Invoke();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playersOnButton--;
            if (playersOnButton <= 0)
            {
                playersOnButton = 0;
                buttonRenderer.material.color = defaultColor;
                onReleased.Invoke();
            }
        }
    }
}
