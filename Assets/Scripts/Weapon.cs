using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float range;
    public int amount;
    public float coolDown;
    public float coolDownTimer;

    public void UseOn(Entity entity)
    {
        if (coolDownTimer < 0)
        {
            entity.TakeDamage(this);
            coolDownTimer = coolDown;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;
    }
}
