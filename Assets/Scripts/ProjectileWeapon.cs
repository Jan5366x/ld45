using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    // Start is called before the first frame update

    public void Fire()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }
    }
}