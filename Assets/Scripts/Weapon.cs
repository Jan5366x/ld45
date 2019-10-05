using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float range;
    public int amount;
    public float coolDown;
    public float coolDownTimer;

    public bool used;

    public void UseOn(Entity entity)
    {
        if ((entity.transform.position - transform.position).magnitude > range)
        {
            return;
        }

        if (coolDownTimer < 0)
        {
            entity.TakeDamage(this);
            used = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (used)
        {
            Animator animator = GetComponent<Animator>();
            if (animator)
            {
                animator.speed = 1 / coolDown;
                animator.SetTrigger("OnHit");
            }

            coolDownTimer = coolDown;
            used = false;
        }

        coolDownTimer -= Time.deltaTime;
    }
}