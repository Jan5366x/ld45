using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float angle;
    public float speed;

    private void Start()
    {
        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = quat;
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * Vector3.right * speed);
    }
}
