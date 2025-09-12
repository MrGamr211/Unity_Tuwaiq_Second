using UnityEngine;

public class EnableCursor : MonoBehaviour
{
void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
