﻿using System;
using UnityEngine;

public class SlimeAggression : MonoBehaviour
{
    public const String AGGRESSIVE = "Aggressive";

    public static int aggressionCounter = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            GetComponentInParent<EnemyMovement>().isAggressive = true;
            Animator animator = GetComponentInParent<Animator>();
            if (AnimationHelper.hasParameter(animator, AGGRESSIVE))
            {
                animator.SetBool(AGGRESSIVE, true);
            }

            RandomizedSounds.Play(gameObject.transform.parent, RandomizedSounds.SPOTTED);
            aggressionCounter++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            GetComponentInParent<EnemyMovement>().isAggressive = false;
            Animator animator = GetComponentInParent<Animator>();
            if (AnimationHelper.hasParameter(animator, AGGRESSIVE))
            {
                animator.SetBool(AGGRESSIVE, false);
            }

            aggressionCounter--;
        }
    }
}