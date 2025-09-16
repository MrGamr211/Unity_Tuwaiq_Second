using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeName : MonoBehaviour
{
    public GameObject DesplayedName;
    public GameObject RealName;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.F4))
        {
            DesplayedName.SetActive(false);
            RealName.SetActive(true);
            Debug.Log("Working");
        }
    }
}
