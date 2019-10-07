using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float coolDown;
    public float coolDownCounter;

    public List<Entity> entitiesInRange = new List<Entity>();

    public void Fire()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        coolDownCounter -= Time.deltaTime;
        if (coolDownCounter < 0)
        {
            if (entitiesInRange.Count > 0)
            {
                Fire();
                coolDownCounter = coolDown;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity otherEntity = other.GetComponent<Entity>();
        if (otherEntity)
        {
            entitiesInRange.Add(otherEntity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Entity otherEntity = other.GetComponent<Entity>();
        if (otherEntity)
        {
            entitiesInRange.RemoveAll(entity => entity.Equals(otherEntity));
        }
    }
}