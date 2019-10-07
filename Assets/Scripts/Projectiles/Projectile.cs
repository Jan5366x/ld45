using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool damagePlayer = false;
    public bool damageEnemies = true;
    public int damage = 10;
    public Transform impactPrefab;

    private void Start()
    {
        Destroy(gameObject, 20);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity otherUnit = other.GetComponent<Entity>();

        // ignore invalid units
        if (otherUnit == null || (otherUnit.isPlayer && !damagePlayer) || (!otherUnit.isPlayer && !damageEnemies) ||
            otherUnit.IsDead())
            return;

        otherUnit.TakeDamage(damage);

        Die();
    }

    public void Die()
    {
        Vector3 spawnPos = transform.position;

        if (impactPrefab != null)
            Instantiate(impactPrefab, spawnPos, Quaternion.identity);
        Destroy(gameObject);
    }
}