using UnityEngine;
using UnityEngine.Assertions;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    public float speed;
    public float minDistance;
    public float maxDistance;
    public float sensingRange;
    public Vector3 delta;

    private void LoadPlayer()
    {
        if (!_player)
        {
            _player = GameObject.FindWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        LoadPlayer();
        delta = _player.transform.position - transform.position;
        if (delta.magnitude < sensingRange)
        {
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            if (delta.magnitude < minDistance)
            {
                rigidbody.AddForce(-speed * delta.normalized);
            }
            else if (delta.magnitude > maxDistance)
            {
                rigidbody.AddForce(speed * delta.normalized);
            }
        }
    }

    private void Update()
    {
        LoadPlayer();
        Weapon weapon = GetComponentInParent<Weapon>();
        if (weapon)
        {
            Entity playerEntity = _player.GetComponent<Entity>();
            if (playerEntity)
            {
                weapon.UseOn(playerEntity);
            }
        }
    }
}