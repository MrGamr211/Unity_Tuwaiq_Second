using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Lives")]
    public int player1Lives = 3;
    public int player2Lives = 3;

    [Header("Game State")]
    public bool isOvertime = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // keep brain alive between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this at the end of every mini-game
    public void ResolveRound(bool p1Won, bool p2Won)
    {
        // 1. Both win → nothing
        if (p1Won && p2Won)
        {
            Debug.Log("Both players won → no life change");
        }
        // 2. Both lose → both -1 life
        else if (!p1Won && !p2Won)
        {
            player1Lives--;
            player2Lives--;
            Debug.Log("Both players lost → -1 life each");
        }
        // 3. Life Steal rule
        else if (p1Won && !p2Won)
        {
            player1Lives++;
            player2Lives--;
            Debug.Log("P1 steals life from P2!");
        }
        else if (!p1Won && p2Won)
        {
            player1Lives--;
            player2Lives++;
            Debug.Log("P2 steals life from P1!");
        }

        // 4. Check for overtime or game over
        CheckGameEnd();
    }

    private void CheckGameEnd()
    {
        if (player1Lives <= 0 && player2Lives <= 0)
        {
            // Both dead → Overtime
            isOvertime = true;
            Debug.Log("OVERTIME STARTS!");
            // reload another mini-game (placeholder)
            LoadRandomMiniGame();
        }
        else if (player1Lives <= 0)
        {
            Debug.Log("Player 2 Wins!");
            LoadMenu();
        }
        else if (player2Lives <= 0)
        {
            Debug.Log("Player 1 Wins!");
            LoadMenu();
        }
        else
        {
            // keep game going → next mini-game
            LoadRandomMiniGame();
        }
    }

    // Dummy placeholder — replace with your selector later
    private void LoadRandomMiniGame()
    {
        // Example: assumes scenes are named "MiniGame1", "MiniGame2"
        string[] miniGames = { "MiniGame1", "MiniGame2" };
        string chosen = miniGames[Random.Range(0, miniGames.Length)];
        SceneManager.LoadScene(chosen);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
