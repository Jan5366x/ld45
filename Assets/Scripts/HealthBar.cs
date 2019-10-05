using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnGUI()
    {
        Entity entity = transform.parent.GetComponent<Entity>();
        if (entity)
        {
            var pos = Camera.main.WorldToScreenPoint(entity.transform.position);
            Rect rect = new Rect(pos.x - 100, Camera.main.pixelHeight - pos.y, 200, 20);
            IMUIHelper.DrawFilledBorderRect(rect, 1, entity.health / (float) entity.maxHealth, Color.black,
                Color.green);    
        }
    }
}