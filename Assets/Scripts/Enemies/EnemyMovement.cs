using UnityEngine;
using UnityEngine.Assertions;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    public float speedNormal;
    public float speedAggressive;
    public bool isAggressive;
    public float distanceChangedCount;
    public float distanceChangeDuration;

    public Vector3 targetPosition;

    public float minDistance;
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
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        distanceChangedCount -= Time.deltaTime;

        if (isAggressive)
        {
            targetPosition = _player.transform.position;
        }
        else
        {
            if (distanceChangedCount < 0)
            {
                targetPosition = transform.position + Random.onUnitSphere;
                targetPosition.z = 0;
                distanceChangedCount = distanceChangeDuration;
            }
        }


        delta = targetPosition - transform.position;
        if (delta.magnitude < sensingRange)
        {
            if (delta.magnitude > minDistance)
            {
                rigidbody.AddForce((isAggressive ? speedAggressive : speedNormal) * delta.normalized);
            }
        }
    }

    private void Update()
    {
        if (isAggressive)
        {
            bool used = false;

            AbstractWeapon weapon = GetComponentInChildren<AbstractWeapon>();
            if (weapon)
            {
                foreach (var entity in weapon.entitiesInRange)
                {
                    if (entity.isPlayer)
                    {
                        used |= weapon.UseOn(entity);
                    }
                }
            }
            
            if (used)
            {
                RandomizedSounds.Play(transform, RandomizedSounds.ATTACK);
            }
        }
    }
}