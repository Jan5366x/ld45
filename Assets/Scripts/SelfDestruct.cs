using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float durationSeconds;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, durationSeconds);
    }

    // Update is called once per frame
    void Update()
    {
    }
}