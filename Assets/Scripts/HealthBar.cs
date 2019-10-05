using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float width = 200;
    public float height = 20;

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
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            Rect rect = new Rect(pos.x - 100, Camera.main.pixelHeight - pos.y, width, height);
            IMUIHelper.DrawFilledBorderRect(rect, 1, entity.health / (float) entity.maxHealth, Color.black,
                Color.green);
        }
    }
}