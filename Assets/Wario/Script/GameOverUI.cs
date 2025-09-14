using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    public void ShowWinner(string winner)
    {
        gameObject.SetActive(true);
        winnerText.text = winner + " Wins!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
