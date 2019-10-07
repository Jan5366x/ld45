using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public Transform rewardPrefab;

    void Start()
    {
        MainMenu.victory = true;
        GameObject playerObject = GameObject.FindWithTag("Player");
        Entity playerEntity = playerObject.GetComponent<Entity>();
        playerEntity.Die();

        Instantiate(rewardPrefab, transform);
    }
}