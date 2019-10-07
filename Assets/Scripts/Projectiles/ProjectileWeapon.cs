using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float coolDown;

    public float coolDownCounter;
    // Start is called before the first frame update

    public void Fire()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        coolDownCounter -= Time.deltaTime;
        if (coolDownCounter < 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Fire();
                coolDownCounter = coolDown;
            }
        }
    }
}