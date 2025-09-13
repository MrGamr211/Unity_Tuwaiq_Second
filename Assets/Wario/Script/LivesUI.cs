using UnityEngine;
using TMPro; // if you use TextMeshPro

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI player1LivesText;
    public TextMeshProUGUI player2LivesText;

    private void OnEnable()
    {
        // Subscribe to GameManager’s update event
        GameManager.OnLivesChanged += UpdateLivesDisplay;

        // Immediately refresh with current values
        if (GameManager.Instance != null)
        {
            UpdateLivesDisplay(GameManager.Instance.player1Lives, GameManager.Instance.player2Lives);
        }
    }

    private void OnDisable()
    {
        GameManager.OnLivesChanged -= UpdateLivesDisplay;
    }

    private void UpdateLivesDisplay(int p1Lives, int p2Lives)
    {
        player1LivesText.text = "P1 Lives: " + p1Lives;
        player2LivesText.text = "P2 Lives: " + p2Lives;
    }
}
