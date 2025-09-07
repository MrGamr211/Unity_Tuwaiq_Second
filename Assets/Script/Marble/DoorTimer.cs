using UnityEngine;

public class DoorTimer : MonoBehaviour
{
    [Header("Door Settings")]
    public Vector3 openOffset = new Vector3(0, 5, 0); // how far door moves
    public float speed = 3f;
    public int PlayersActive = 2;  // number of buttons required

    [Header("Timer Settings")]
    public float openDuration = 5f; // how long the door stays open

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;
    private int activeButtons = 0;
    private float timer = 0f;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    void Update()
    {
        // Handle timer countdown
        if (isOpen && timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                CloseDoor();
            }
        }

        // Smooth door movement
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
    }

    private void CheckDoorState()
    {
        // When enough buttons are pressed, start timer + open door
        if (activeButtons >= PlayersActive)
        {
            OpenDoor();
            timer = openDuration; // reset timer
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Door opened! Timer started.");
    }

    private void CloseDoor()
    {
        isOpen = false;
        Debug.Log("Door closed!");
    }
}
