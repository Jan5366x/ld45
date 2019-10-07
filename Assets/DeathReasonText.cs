using TMPro;
using UnityEngine;

public class DeathReasonText : MonoBehaviour
{
    private const string ARMOR = "The protector of the island\r\nmislikes your cursed armor";
    private const string SWORD = "The protector of the island\r\nmislikes your cursed sword";
    private const string NAKED = "You were to weak to survive\r\nTry harder!";

    void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        switch (MainMenu.choice)
        {
            case 0:
                text.SetText(ARMOR);
                break;
            case 1:
                text.SetText(SWORD);
                break;
            case 2:
                text.SetText(NAKED);
                break;
        }
    }
}