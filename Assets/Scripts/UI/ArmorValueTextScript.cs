using UI;
using UnityEngine;

public class ArmorValueTextScript : AbstractPlayerValueTextUpdate
{
    protected override string FetchValue()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
            return "0%";
        
        Armor armor = player.GetComponentInChildren<Armor>();
        return (armor == null ? 0F : armor.damagePercentage) + "%";
    }
}
