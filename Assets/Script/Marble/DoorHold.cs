using UnityEngine;

public class DoorHold : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(0, 5, 0); // how far it moves when open
    public float speed = 3f;
    public int PlayersActive = 2;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;
    private int activeButtons = 0; // tracks how many buttons are pressed

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    void Update()
    {
        Vector3 target = isOpen ? openPosition : closedPosition;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }

    // Called by button
    public void ButtonPressed()
    {
        activeButtons++;
        CheckDoorState();
    }

    // Called by button
    public void ButtonReleased()
    {
        activeButtons--;
        if (activeButtons < 0) activeButtons = 0; // safety
        CheckDoorState();
    }

    private void CheckDoorState()
    {
        // Example: require 2 buttons
        if (activeButtons >= PlayersActive)
            isOpen = true;
        else
            isOpen = false;
    }
}
