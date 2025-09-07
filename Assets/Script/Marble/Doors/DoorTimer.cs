using UnityEngine;
using TMPro; // Needed for TextMeshPro

public class DoorTimer : MonoBehaviour
{
    [Header("Door Settings")]
    public Vector3 openOffset = new Vector3(0, 5, 0);
    public float speed = 3f;
    public int PlayersActive = 2;

    [Header("Timer Settings")]
    public float openDuration = 5f;
    private float timer = 0f;

    [Header("UI Settings")]
    public TextMeshProUGUI timerText; // Assign in Inspector

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;
    private int activeButtons = 0;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;

        if (timerText != null)
            timerText.text = ""; // hide at start
    }

    void Update()
    {
        // Timer countdown
        if (isOpen && timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timerText != null)
                timerText.text = Mathf.Ceil(timer).ToString(); // show whole seconds

            if (timer <= 0f)
            {
                CloseDoor();
            }
        }

        // Smooth door animation
        Vector3 target = isOpen ? openPosition : closedPosition;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }

    public void ButtonPressed()
    {
        activeButtons++;
        CheckDoorState();
    }

    public void ButtonReleased()
    {
        activeButtons--;
        if (activeButtons < 0) activeButtons = 0;
    }

    private void CheckDoorState()
    {
        if (activeButtons >= PlayersActive)
        {
            OpenDoor();
            timer = openDuration;

            if (timerText != null)
                timerText.text = Mathf.Ceil(timer).ToString();
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

        if (timerText != null)
            timerText.text = ""; // hide text when closed
    }
}
