using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float width = 200;
    public float height = 20;

    private void OnGUI()
    {
        Entity entity = transform.parent.GetComponent<Entity>();
        if (entity)
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            Rect rect = new Rect(pos.x - width / 2, Camera.main.pixelHeight - pos.y, width, height);
            IMUIHelper.DrawFilledBorderRect(rect, 1, entity.health / (float) entity.maxHealth, Color.black,
                Color.green);
        }
    }
}