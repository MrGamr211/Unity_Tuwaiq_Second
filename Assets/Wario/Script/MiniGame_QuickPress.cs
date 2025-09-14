using UnityEngine;

public class MiniGame_QuickPress : MonoBehaviour
{
    public float timeLimit = 3f; // seconds to react
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        // Player 1 presses "A"
        if (Input.GetKeyDown(KeyCode.A))
        {
            EndMiniGame(true, false);
        }
        // Player 2 presses "L"
        else if (Input.GetKeyDown(KeyCode.L))
        {
            EndMiniGame(false, true);
        }

        // Time runs out → both lose
        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0f)
        {
            EndMiniGame(false, false);
        }
    }

    void EndMiniGame(bool p1Win, bool p2Win)
    {
        gameEnded = true;
        Debug.Log($"Mini-game ended → P1Win:{p1Win}, P2Win:{p2Win}");
        GameManager.Instance.ResolveRound(p1Win, p2Win);
    }
}
