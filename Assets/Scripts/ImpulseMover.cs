using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseMover : MonoBehaviour
{
    public Vector2 direction;
    public float acceleration;
    public Rigidbody rb;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(direction.normalized * acceleration, ForceMode.Impulse);
        }
    }
}
