using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SortingOrderScript : MonoBehaviour {

    public float offset;
    
    void Awake()
    {
        SetPosition();
    }

    void Update()
    {
        SetPosition();
    }

    void SetPosition()
    {
        GetComponent<SpriteRenderer>().sortingOrder = (int)-((transform.position.y + offset) * 100);
    }

}
