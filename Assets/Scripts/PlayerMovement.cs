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
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        bool forwards = vertical <= 0;

        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            Debug.Log(animator.parameters);
            animator.SetBool("Forwards", forwards);
        }


        Weapon weapon = GetComponentInChildren<Weapon>();

        if (weapon)
        {
            if (forwards)
            {
                weapon.transform.SetParent(transform.Find("HandForwards"), false);
            }
            else
            {
                weapon.transform.SetParent(transform.Find("HandBackwards"), false);
            }
        }
    }
}