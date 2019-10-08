using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : AbstractWeapon
{
    public GameObject projectilePrefab;

    public override bool UseOn(Entity target)
    {
        if (coolDownCounter < 0)
        {
            if (target)
            {
                var transformPosition = target.transform.position;
                var myPosition = transform.position;
                Vector3 delta = new Vector3(transformPosition.x - myPosition.x, transformPosition.y - myPosition.y, 0);
                GameObject projectileObject = Instantiate(projectilePrefab, myPosition, transform.rotation);
                projectileObject.GetComponent<ProjectileMovement>().direction = delta.normalized;

                Projectile projectile = projectileObject.GetComponentInChildren<Projectile>();
                if (projectile)
                {
                    projectile.damagePlayer = target.isPlayer;
                    projectile.damageEnemies = !target.isPlayer;
                }

                used = true;
                return true;
            }
        }

        return false;
    }

    public override Animator GetAnimator()
    {
        return GetComponentInParent<Animator>();
    }

    public override void OnDrop()
    {
        
    }
}