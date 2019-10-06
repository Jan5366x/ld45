using System;
using UnityEngine;

public class SlimeAggression : MonoBehaviour
{
    public const String AGGRESSIVE = "Aggressive";

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
        }
    }
}