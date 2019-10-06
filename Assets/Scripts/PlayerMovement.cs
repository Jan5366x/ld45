using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public const String IDLE = "Idle";
    public const String DIRECTION = "Direction";
    public const String SHOW_RIGHT = "ShowRight";
    public float movementSpeed = 10;
    private bool forceIdleWeapon;

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
                if (AnimationHelper.hasParameter(animator, IDLE))
                {
                    animator.SetBool(IDLE, true);
                }
            }
            else
            {
                if (AnimationHelper.hasParameter(animator, IDLE))
                {
                    animator.SetBool(IDLE, false);
                }

                if (AnimationHelper.hasParameter(animator, DIRECTION))
                {
                    animator.SetInteger(DIRECTION, direction);
                }

                if (AnimationHelper.hasParameter(animator, SHOW_RIGHT))
                {
                    if (right)
                    {
                        animator.SetBool(SHOW_RIGHT, true);
                    }
                    else
                    {
                        animator.SetBool(SHOW_RIGHT, false);
                    }
                }
            }

            Debug.Log(animator.parameters);
        }

        Weapon weapon = GetComponentInChildren<Weapon>();
        HandleWeapon(weapon, idle, direction);

    }



    private void HandleWeapon(Weapon weapon, bool idle, int direction)
    {
        if (weapon)
        {
            if (!idle || forceIdleWeapon)
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

            forceIdleWeapon = false;
        }
    }
    
    public void OnSwitchWeapon()
    {
        forceIdleWeapon = true;
    }
}