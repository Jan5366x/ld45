using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    private void OnGUI()
    {
        Entity player = GameObject.Find("Player").GetComponentInChildren<Entity>();
        slider.value = player.health / player.maxHealth;
    }
}