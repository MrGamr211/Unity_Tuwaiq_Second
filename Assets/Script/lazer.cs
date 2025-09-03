using System.Collections;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public Camera playerCamera;
    public Transform LaserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.24f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, LaserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                if (hit.collider.name == "Hello")
                {
                    //Destroy(hit.transform.gameObject);
                    Debug.Log("Hit!");
                }

            }

            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }

            StartCoroutine(ShootLaser());
        }
    }
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
