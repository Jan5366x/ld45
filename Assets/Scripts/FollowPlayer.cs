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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

            speedX = speed * delta.x * Time.deltaTime;
            speedY = speed * delta.y * Time.deltaTime;

            transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        }
    }
}
