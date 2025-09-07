using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class ColliderTriggerChangeScene : MonoBehaviour
{
    public string SceneName;
    public int playersOnTrigger = 2;
    private int players = 0;
    void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            players++;
            if (players == playersOnTrigger) SceneManager.LoadScene(SceneName);
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
