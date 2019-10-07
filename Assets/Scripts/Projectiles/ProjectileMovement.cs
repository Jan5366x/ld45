using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    void Update()
    {
        transform.Translate(Time.deltaTime * direction * speed);
    }
}