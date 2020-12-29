using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    bool isGrounded;
    public static float verticalImpulse=3;


    //public void easy()


    public void FixedUpdate()
    {
        Vector3 direction = Vector3.right * variableJoystick.Horizontal;            //Jump
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        if (variableJoystick.Vertical>0.5)
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, verticalImpulse), ForceMode.Impulse);
                Debug.Log("JumpButton");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;

    }
}