using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class ColliderTriggerChangeScene2D : MonoBehaviour
{
    public string SceneName;
    public int playersOnTrigger = 2;
    public int players = 0;
    public static event System.Action<int> OnPlayersChanged;
    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            players++;
            //if (players == playersOnTrigger) SceneManager.LoadScene(SceneName);
        }
    }

public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            players--;
            if (players <= 0) players = 0;
        }
  }

  // this code are taken from this video (https://youtube.com/shorts/qCKmtIKmRyQ?si=Vb5KhQPRKor-bghq)
  // public void LoadSceneByName()
  // {
  //     SceneManager.LoadScene("SandBox");
  // }
  // public void LoadNextInBuild()
  // {
  //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  // }
}
