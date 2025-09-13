using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGame_Spam : MonoBehaviour
{
    public int targetPresses = 20;  // how many presses needed to win
    public float timeLimit = 5f;    // max time allowed

    private int player1Count = 0;
    private int player2Count = 0;
    private float timer = 0f;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timer += Time.deltaTime;

        // If time runs out → decide winner by who pressed more
        if (timer >= timeLimit)
        {
            EndMiniGame(player1Count > player2Count, player2Count > player1Count);
        }
    }

    // Input System callback for Player 1
    public void OnPlayer1Spam(InputAction.CallbackContext context)
    {
        if (gameEnded) return;
        if (context.performed)
        {
            player1Count++;
            Debug.Log("Player1");
            if (player1Count >= targetPresses)
            {
                EndMiniGame(true, false);
            }
        }
    }

    // Input System callback for Player 2
    public void OnPlayer2Spam(InputAction.CallbackContext context)
    {
        if (gameEnded) return;
        if (context.performed)
        {
            player2Count++;
            Debug.Log("player2");
            if (player2Count >= targetPresses)
            {
                EndMiniGame(false, true);
            }
        }
    }

    void EndMiniGame(bool p1Win, bool p2Win)
    {
        gameEnded = true;
        Debug.Log($"Spam Mini-Game End → P1Win:{p1Win}, P2Win:{p2Win}");
        GameManager.Instance.ResolveRound(p1Win, p2Win);
    }
}
