using UI;
using UnityEngine;

public class WeaponSpeedTextScript : AbstractPlayerValueTextUpdate
{
    protected override string FetchValue()
    {

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
            return "0";
        
        Weapon weapon = player.GetComponentInChildren<Weapon>();
        return (weapon == null ? 0F : weapon.coolDown).ToString();
    }
}
