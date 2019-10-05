using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool wasDead;

    public void TakeDamage(Weapon weapon)
    {
        health -= weapon.amount;

        Transform damageTaken = Resources.Load<Transform>("Objects/DamageTaken");
        Instantiate(damageTaken, transform);
        //TODO: Play some animations / sound / whatever
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

    private void OnGUI()
    {
        if (!IsDead())
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            Rect rect = new Rect(pos.x - 100, Camera.main.pixelHeight - pos.y, 200, 20);
            IMUIHelper.DrawFilledBorderRect(rect, 1, health / (float) maxHealth, Color.red, Color.green);
        }
    }
}