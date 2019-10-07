using UnityEngine;

[ExecuteInEditMode]
public class GridAlignment : MonoBehaviour
{
    [Range(1, 1000)] public float stepsPerUnitX = 100;
    [Range(1, 1000)] public float stepsPerUnitY = 100;


    [ContextMenu("Align")]
    public void Align()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Floor(position.x * stepsPerUnitX) / stepsPerUnitX;
        position.y = Mathf.Floor(position.y * stepsPerUnitY) / stepsPerUnitY;
        position.z = 0;

        transform.position = position;
    }

    private void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            Vector2 size = GetComponent<SpriteRenderer>().size;
            stepsPerUnitX = 1 / size.x;
            stepsPerUnitY = 1 / size.y;
        }

        Align();
    }
}