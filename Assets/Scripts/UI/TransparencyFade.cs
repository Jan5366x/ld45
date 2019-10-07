using UnityEngine;

public class TransparencyFade : MonoBehaviour
{
    public float minOpacity = 0.3f;
    public float fadeOutDuration = 0.5f;
    public float fadeInDuration = 0.5f;
    public int steps = 100;


    private bool doFade;
    private bool fadeOut;
    private float fadeTime;
    private float fadeValueStart;

    private void Update()
    {
        if (doFade)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            if (fadeOut)
            {
                if (fadeTime > fadeOutDuration)
                {
                    color.a = minOpacity;
                    doFade = false;
                }

                color.a = Mathf.Lerp(fadeValueStart, minOpacity, fadeTime / fadeOutDuration);
            }
            else
            {
                if (fadeTime > fadeInDuration)
                {
                    color.a = 1;
                    doFade = false;
                }

                color.a = Mathf.Lerp(fadeValueStart, 1, fadeTime / fadeInDuration);
            }

            spriteRenderer.color = color;
            fadeTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<Player>())
        {
            fadeTime = 0;
            fadeValueStart = GetComponent<SpriteRenderer>().color.a;
            doFade = true;
            fadeOut = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponentInParent<Player>())
        {
            fadeTime = 0;
            fadeValueStart = GetComponent<SpriteRenderer>().color.a;
            doFade = true;
            fadeOut = false;
        }
    }
}