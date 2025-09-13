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
        NotifyLivesChanged();
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

        // Clamp lives so they never go negative
        player1Lives = Mathf.Max(0, player1Lives);
        player2Lives = Mathf.Max(0, player2Lives);

        // 4. Check for overtime or game over
        CheckGameEnd();

        // Update UI
        NotifyLivesChanged();
    }

    private void CheckGameEnd()
    {
        if (player1Lives <= 0 && player2Lives <= 0)
        {
            // Both dead → Overtime
            isOvertime = true;
            Debug.Log("OVERTIME STARTS!");
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
            LoadRandomMiniGame();
        }
    }

    // Dummy placeholder — replace with your selector later
    private void LoadRandomMiniGame()
    {
        string[] miniGames = { "MiniGame1" };
        string chosen = miniGames[Random.Range(0, miniGames.Length)];
        SceneManager.LoadScene(chosen);
        NotifyLivesChanged();
    }

    public void LoadMenu()
    {
        // Reset everything when going back to menu
        player1Lives = 3;
        player2Lives = 3;
        isOvertime = false;

        // Update UI
        NotifyLivesChanged();

        SceneManager.LoadScene("MainMenu");
    }

    public static event System.Action<int, int> OnLivesChanged;

    private void NotifyLivesChanged()
    {
        OnLivesChanged?.Invoke(player1Lives, player2Lives);
    }

}
