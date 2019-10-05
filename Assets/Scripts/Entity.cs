using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool wasDead;
    public bool isPlayer = false;

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

            Transform damageTaken = Resources.Load<Transform>("Objects/DamageTaken");
            Transform newTransform = Instantiate(damageTaken, transform);
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
        Destroy(gameObject);
        //TODO: Play some animations / sound / whatever
    }

    // Start is called before the first frame update
    void Start()
    {
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
}