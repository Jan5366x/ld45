using TMPro;
using UnityEngine;

public class GameOverToggler : MonoBehaviour
{
    private const string ARMOR_MESSAGE = "The protector of the island\r\nmislikes your cursed armor";
    private const string SWORD_MESSAGE = "The protector of the island\r\nmislikes your cursed sword";
    private const string NAKED_MESSAGE = "You were to weak to survive\r\nTry harder!";
    private const string VICTORY_MESSAGE = "The protector of the island\r\nrevels in your victory";
    private const string GAME_OVER = "GAME OVER";
    private const string VICTORY = "VICTORY";

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI deathMessage;
    public GameObject reaper;


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
        if (triggered)
        {
            reaper.SetActive(!MainMenu.victory);
            if (MainMenu.victory)
            {
                gameOverText.SetText(VICTORY);
                deathMessage.SetText(VICTORY_MESSAGE);
            }
            else
            {
                gameOverText.SetText(GAME_OVER);

                switch (MainMenu.choice)
                {
                    case 0:
                        deathMessage.SetText(ARMOR_MESSAGE);
                        break;
                    case 1:
                        deathMessage.SetText(SWORD_MESSAGE);
                        break;
                    case 2:
                        deathMessage.SetText(NAKED_MESSAGE);
                        break;
                }
            }
        }
    }
}