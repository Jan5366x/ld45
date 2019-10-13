using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{
    [Range(0, 100)] public float damagePercentage = 100;
    public Sprite previewImage;

    public Transform dropArmor;

    private void Start()
    {
        Entity entity = GetComponentInParent<Entity>();
        if (entity)
        {
            entity.OnSwitchArmor(this);
        }

        PlayerMovement player = GetComponentInParent<PlayerMovement>();
        if (player)
        {
            GameObject armorImagePreview = GameObject.Find("ArmorImagePreview");
            Image image = armorImagePreview.GetComponent<Image>();
            image.sprite = previewImage;
        }
    }

    public void OnDrop()
    {
        if (dropArmor)
        {
            Instantiate(dropArmor,
                LandHelper.ChooseLand(transform.position, new Rect(-1, -2, 2, 3)), transform.rotation);
        }
    }
}