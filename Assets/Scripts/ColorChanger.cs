using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public float updateDuration;
    public float updateCounter;

    // Update is called once per frame
    void Update()
    {
        updateCounter -= Time.deltaTime;
        if (updateCounter < 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer)
            {
                spriteRenderer.color = Random.ColorHSV();
                updateCounter = updateDuration;
            }
        }
    }
}