using System.Collections;
using TMPro;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    private static int total;
    private static int current;

    private static TextMeshProUGUI text;

    public static void Add(int amount)
    {
        total += amount;
        //TODO: Play some sound
    }

    IEnumerator UpdateCounter()
    {
        while (true)
        {
            if (current <= total)
            {
                text.text = "" + current;
                if (total - current > 100)
                {
                    current += 10;
                }
                else if (total - current > 10)
                {
                    current += 2;
                }
                else
                {
                    current++;
                }
            }

            yield return new WaitForSeconds(1f / 60f);
        }
    }

    private void Start()
    {
        total = 0;
        current = 0;
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine("UpdateCounter");
    }
}