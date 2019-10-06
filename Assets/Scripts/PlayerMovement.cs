using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if (!Mathf.Approximately(vertical, 0f) || !Mathf.Approximately(horizontal, 0f))
        {
            rigidbody.velocity = new Vector2(horizontal, vertical) * movementSpeed;
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }

        bool idle = Mathf.Approximately(vertical, 0f) && Mathf.Approximately(horizontal, 0f);

        bool right = horizontal > 0;
        bool left = horizontal < 0;
        bool forward = vertical < 0;
        bool backward = vertical > 0;

        int direction = forward ? 0 : left ? 1 : backward ? 2 : 3;

        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            if (idle)
            {
                if (hasParameter(animator, "Idle"))
                {
                    animator.SetBool("Idle", true);
                }
            }
            else
            {
                if (hasParameter(animator, "Idle"))
                {
                    animator.SetBool("Idle", false);
                }

                if (hasParameter(animator, "Direction"))
                {
                    animator.SetInteger("Direction", direction);
                }

                if (hasParameter(animator, "ShowRight"))
                {
                    if (right)
                    {
                        animator.SetBool("ShowRight", true);
                    }
                    else
                    {
                        animator.SetBool("ShowRight", false);
                    }
                }
            }

            Debug.Log(animator.parameters);
        }

        Weapon weapon = GetComponentInChildren<Weapon>();

        if (weapon)
        {
            if (!idle)
            {
                switch (direction)
                {
                    case 0:
                        weapon.transform.SetParent(transform.Find("HandForwards"), false);
                        break;
                    case 1:
                        weapon.transform.SetParent(transform.Find("HandLeft"), false);
                        break;
                    case 2:
                        weapon.transform.SetParent(transform.Find("HandBackwards"), false);
                        break;
                    case 3:
                        weapon.transform.SetParent(transform.Find("HandRight"), false);
                        break;
                }
            }
        }
    }

    static bool hasParameter(Animator animator, String parameter)
    {
        foreach (var animatorControllerParameter in animator.parameters)
        {
            if (animatorControllerParameter.name.Equals(parameter))
            {
                return true;
            }
        }

        return false;
    }
}