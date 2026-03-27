using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{   
    public GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
