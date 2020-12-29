using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForseMover : MonoBehaviour
{
    public Vector2 direction;
    public float acceleration;
    public Rigidbody rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(direction.normalized * acceleration);
    }
}
