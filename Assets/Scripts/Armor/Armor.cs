using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
            Vector3 newPosition = transform.position;
            newPosition.x += Random.Range( -1.0f , 1.0f );
            newPosition.y += Random.Range( -2.0f , 1.0f );
            newPosition.z = 0;
            Instantiate(dropArmor, newPosition, transform.rotation);
        }
    }
}