using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    [Header("References")]
    public ColliderTriggerChangeScene2D trigger; // Can be set in Inspector or found automatically

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // If no reference, try to find one in the scene
        if (trigger == null)
        {
            trigger = FindObjectOfType<ColliderTriggerChangeScene2D>();
            if (trigger == null) return; // nothing found, skip
        }

        // Check if two players are inside the trigger
        if (trigger.players == 2)
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Both players detected → Loading Menu...");
        SceneManager.LoadScene("MainMenu 1");
    }
    public void LoadGame()
    {
        Debug.Log("Player pressed on button → Loading Game...");
        SceneManager.LoadScene("test player");
    }
}
