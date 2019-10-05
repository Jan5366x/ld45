using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LoadPlayer();
        if (_player)
        {
            delta = _player.transform.position - transform.position;
            if (delta.magnitude < sensingRange)
            {
                Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
                if (delta.magnitude < minDistance)
                {
                    rigidbody.AddForce(-speed * delta);
                }
                else if (delta.magnitude > maxDistance)
                {
                    rigidbody.AddForce(speed * delta);
                }
                else
                {
//                    rigidbody.velocity = Vector2.zero;
                }
            }
        }
    }
}