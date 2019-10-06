﻿using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool wasDead;
    public bool isPlayer = false;
    public Transform onDeathPrefab;
    public Transform onDamagePrefab;

    public void TakeDamage(int damage2)
    {
        int damage = damage2;
        Armor armor = GetComponentInChildren<Armor>();

        if (armor)
        {
            damage = (int) (damage * armor.damagePercentage / 100f);
        }

        if (damage > 0)
        {
            health -= damage;

            Transform newTransform = Instantiate(onDamagePrefab, transform);
            newTransform.Translate(Random.Range(-0.2f, 0.2f), Random.Range(-0.5f, 0.5f), 0);
            Animation animator = newTransform.GetComponent<Animation>();
            if (animator)
            {
                animator.wrapMode = WrapMode.Once;
            }

            //TODO: Play some animations / sound / whatever
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    private void Die()
    {
        wasDead = true;
        if (onDeathPrefab)
        {
            Instantiate(onDeathPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);
        //TODO: Play some animations / sound / whatever
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!onDamagePrefab)
        {
            onDamagePrefab = Resources.Load<Transform>("Objects/DamageTaken");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead() && !wasDead)
        {
            Die();
            return;
        }
    }

    public void OnSwitchWeapon(Weapon newWeapon)
    {
        foreach (Weapon weapon in GetComponentsInChildren<Weapon>())
        {
            if (!weapon.Equals(newWeapon))
            {
                Destroy(weapon.gameObject);
            }
        }
    }
}