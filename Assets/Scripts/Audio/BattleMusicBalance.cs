using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusicBalance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Animator animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetBool("InBattle", SlimeAggression.aggressionCounter > 0);
        }
    }
}