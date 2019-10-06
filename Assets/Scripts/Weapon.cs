using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int amount;
    public float coolDown;
    public float coolDownTimer;

    public bool used;
    public Sprite previewImage;

    public List<Entity> entitiesInRange = new List<Entity>();

    public void UseOn(Entity entity)
    {
        if (coolDownTimer < 0)
        {
            if (entity)
            {
                entity.TakeDamage(amount);
            }

            used = true;
        }
    }

    private void Start()
    {
        Entity entity = GetComponentInParent<Entity>();
        if (entity)
        {
            entity.OnSwitchWeapon(this);
        }

        PlayerMovement player = GetComponentInParent<PlayerMovement>();
        if (player)
        {
            player.OnSwitchWeapon();
            GameObject swordImagePreview = GameObject.Find("SwordImagePreview");
            Image image = swordImagePreview.GetComponent<Image>();
            image.sprite = previewImage;
        }
    }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity otherEntity = other.GetComponent<Entity>();
        if (otherEntity)
        {
            entitiesInRange.Add(otherEntity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Entity otherEntity = other.GetComponent<Entity>();
        if (otherEntity)
        {
            entitiesInRange.RemoveAll(entity => entity.Equals(otherEntity));
        }
    }
}