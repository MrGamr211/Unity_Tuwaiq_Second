using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Level;
    public void PlayGame()
    {
        SceneManager.LoadScene(Level);
    } 
}
