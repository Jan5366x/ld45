using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Weapon weapon = GetComponentInChildren<Weapon>();
            if (weapon)
            {
                foreach (var entity in weapon.entitiesInRange)
                {
                    if (entity.isPlayer)
                        continue;

                    weapon.UseOn(entity);
                }

                // Draw animation even if we hit nothing
                weapon.UseOn(null);
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Entity entity = GetComponentInParent<Entity>();
            if (entity)
            {
                entity.Heal(10);
            }
        }
    }


}