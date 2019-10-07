using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverToggler : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static bool triggered = false;

    private void Start()
    {
        triggered = false;
    }

    public static void OnDeath()
    {
        triggered = true;
    }

    private void Update()
    {
        gameOverPanel.SetActive(triggered);
    }
}
