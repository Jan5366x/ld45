using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (MainMenu.choice)
        {
            case 0:
                // TODO: Spawn Reaper
                // TODO: Spawn Player with armor
                break;
            case 1:
                // TODO: Spawn Reaper
                // TODO: Spawn Player with sword
                break;
            case 2:
                // TODO: Spawn Player with naked
                break;
            default:
                break;
        }
    }
}
