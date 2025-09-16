using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton1 : MonoBehaviour
{
    public string SceneName;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneName);
            Debug.Log("Chack");
        }
    }
}
