using UnityEngine;

public class Gem : MonoBehaviour
{
    public int worth;

    void Start()
    {
        GemCounter.Add(worth);
    }
}