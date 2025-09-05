using UnityEngine;

public class RayCastt : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
            else
            {
                return;
            }
        }
    }
}

