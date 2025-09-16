using UnityEngine;

public enum ButtonType
{
    Toggle,
    Hold,
    Timer
}

public class Button2D : MonoBehaviour
{
    [Header("Button Settings")]
    public ButtonType buttonType;
    public float timerDuration = 3f;

    [Header("Connected Door or Platform")]
    public Door2D connectedDoor;
    // public Platform2D connectedPlatform2D;

    private bool isPressed = false;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        switch (buttonType)
        {
            case ButtonType.Toggle:
                isPressed = !isPressed;
                connectedDoor.SetOpen(isPressed);
                break;

            case ButtonType.Hold:
                isPressed = true;
                connectedDoor.SetOpen(true);
                break;

            case ButtonType.Timer:
                isPressed = true;
                timer = timerDuration;
                connectedDoor.SetOpen(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (buttonType == ButtonType.Hold)
        {
            isPressed = false;
            connectedDoor.SetOpen(false);
        }
    }

    private void Update()
    {
        if (buttonType == ButtonType.Timer && isPressed)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                isPressed = false;
                connectedDoor.SetOpen(false);
            }
        }
    }
}
