using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float healingPerSecond;
    public bool wasDead;
    public bool isPlayer = false;
    public Transform onDeathPrefab;
    public Transform onDamagePrefab;
    public Rect splatterArea;

    public void TakeDamage(int damageReceived)
    {
        int damage = damageReceived;
        Armor armor = GetComponentInChildren<Armor>();

        if (armor)
        {
            damage = (int) (damage * armor.damagePercentage / 100f);
        }

        if (damage > 0)
        {
            health -= damage;

            Transform newTransform = Instantiate(onDamagePrefab, transform);
            newTransform.Translate(Random.Range(splatterArea.xMin, splatterArea.xMax),
                Random.Range(splatterArea.yMin, splatterArea.yMax), 0);
            Animation animator = newTransform.GetComponent<Animation>();
            if (animator)
            {
                animator.wrapMode = WrapMode.Once;
            }

            //TODO: Play some animations / sound / whatever
        }
    }

    public void Heal(float amount)
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
        StartCoroutine("AutomaticHealing");
        if (!onDamagePrefab)
        {
            onDamagePrefab = Resources.Load<Transform>("Objects/DamageTaken");
        }
    }

    IEnumerator AutomaticHealing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Heal(healingPerSecond);
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

    public void OnSwitchArmor(Armor newArmor)
    {
        foreach (Armor armor in GetComponentsInChildren<Armor>())
        {
            if (!armor.Equals(newArmor))
            {
                Destroy(armor.gameObject);
            }
        }
    }
}