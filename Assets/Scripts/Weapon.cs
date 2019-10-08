using UnityEngine;
using UnityEngine.UI;

public class Weapon : AbstractWeapon
{
    public int amount;
    public Sprite previewImage;

    public override bool UseOn(Entity entity)
    {
        if (coolDownCounter < 0)
        {
            if (entity)
            {
                entity.TakeDamage(amount);
            }

            used = true;
            return true;
        }

        return false;
    }

    public override Animator GetAnimator()
    {
        return GetComponent<Animator>();
    }

    public override void OnDrop()
    {
        if (dropWeapon)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += Random.Range( -2.0f , 1.0f );
            newPosition.y += Random.Range( -2.0f , 1.0f );
            newPosition.z = 0;
            Instantiate(dropWeapon, newPosition, transform.rotation);
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
}