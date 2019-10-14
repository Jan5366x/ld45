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
            Instantiate(dropWeapon, LandHelper.ChooseLand(transform.position, new Rect(-1, -2, 2, 3)),
                transform.rotation);
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
            GameObject swordImagePreview = GameObject.Find("WeaponImagePreview");
            Image image = swordImagePreview.GetComponent<Image>();
            image.sprite = previewImage;
        }
    }
}