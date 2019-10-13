using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Weapon weapon = GetComponentInChildren<Weapon>();
            if (weapon)
            {
                bool used = false;
                foreach (var entity in weapon.entitiesInRange)
                {
                    if (entity.isPlayer)
                        continue;

                    used |= weapon.UseOn(entity);
                }

                if (used)
                {
                    RandomizedSounds.Play(transform, RandomizedSounds.ATTACK);
                }

                // Draw animation even if we hit nothing
                weapon.UseOn(null);
            }
        }
    }
}