using UnityEngine;

public class SplatterColorPicker : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer splatter = GetComponent<SpriteRenderer>();
        if (splatter)
        {
            if (transform.parent)
            {
                SpriteRenderer parent = transform.parent.GetComponent<SpriteRenderer>();
                if (parent)
                {
                    splatter.color = parent.color;
                }
            }
        }
    }
}