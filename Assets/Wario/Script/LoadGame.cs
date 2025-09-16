using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGameB()
    {
        Debug.Log("Player pressed on button → Loading Game...");
        SceneManager.LoadScene("test player");
    }
}
