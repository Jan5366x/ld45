using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public bool isFollowing;
    public float speed;
    public float speedX;
    public float speedY;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 delta = player.transform.position - transform.position;
            if (delta.magnitude > 10)
            {
                isFollowing = true;
            }

            if (delta.magnitude < 3)
            {
                isFollowing = false;
            }

            if (isFollowing)
            {
                delta.Normalize();
                speedX = speed * delta.x;
                speedY = speed * delta.y;

                transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
            }
        }
    }
}
