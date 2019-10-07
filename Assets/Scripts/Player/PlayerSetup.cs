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
                // TODO: Give armor to player
                break;
            case 1:
                // TODO: Spawn Reaper
                // TODO: Give sword to player
                break;
            case 2:
                // TODO: Spawn player naked
                break;
            default:
                break;
        }
    }
}
