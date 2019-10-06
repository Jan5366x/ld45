using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    private void OnGUI()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject)
        {
            Entity player = playerObject.GetComponentInChildren<Entity>();
            if (player)
            {
                slider.value = player.health / player.maxHealth;
            }
        }
        else
        {
            slider.value = 0;
        }
    }
}