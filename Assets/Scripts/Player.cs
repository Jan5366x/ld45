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
            Weapon weapon = GetComponentInParent<Weapon>();
            float range = weapon.range;
            var position = transform.position;
            Collider2D[] hitEntities = Physics2D.OverlapCircleAll(new Vector2(position.x, position.y), range);
            foreach (var hitEntity in hitEntities)
            {
                if (!hitEntity.gameObject.GetComponent<Player>())
                {
                    Entity entity = hitEntity.gameObject.GetComponent<Entity>();
                    if (entity)
                    {
                        weapon.UseOn(entity);
                    }
                }
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