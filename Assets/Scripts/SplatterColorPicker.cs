using UnityEngine;

public class SplatterColorPicker : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer splatter = GetComponent<SpriteRenderer>();
        SpriteRenderer parent = transform.parent.GetComponent<SpriteRenderer>();
        splatter.color = parent.color;
    }
}