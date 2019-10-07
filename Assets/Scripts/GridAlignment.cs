using System;
using UnityEngine;

[ExecuteInEditMode]
public class GridAlignment : MonoBehaviour
{
    [Range(1, 1000)] public double stepsPerUnitX = 100;
    [Range(1, 1000)] public double stepsPerUnitY = 100;


    private void Awake()
    {
        if (Application.isPlaying)
        {
            enabled = false;
        }
    }

    [ContextMenu("Align")]
    public void Align()
    {
        Vector3 position = transform.position;
        position.x = (float) (Math.Round(position.x * stepsPerUnitX) / stepsPerUnitX);
        position.y = (float) (Math.Round(position.y * stepsPerUnitY) / stepsPerUnitY);
        position.z = 0;

        transform.position = position;
    }

    private void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer)
        {
            Vector2 size = GetComponent<SpriteRenderer>().size;
            stepsPerUnitX = 1d / (double) size.x;
            stepsPerUnitY = 1d / (double) size.y;
        }

        Align();
    }
}