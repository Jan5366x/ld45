using UI;
using UnityEngine;

public class WeaponDamageTextScript : AbstractPlayerValueTextUpdate
{
    protected override string FetchValue()
    {

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
            return "0";
        
        Weapon weapon = player.GetComponentInChildren<Weapon>();
        return (weapon == null ? 0F : weapon.amount).ToString();
    }
}
