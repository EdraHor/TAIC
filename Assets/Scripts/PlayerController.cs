using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{ 
    public float horizontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody rb;
    private Joystick joystick;
    bool isGrounded;
    bool movement;
    public Vector2 direction;
    public float acceleration;
    public VariableJoystick variableJoystick;

    public void harder()
    {
        JoystickPlayerExample.verticalImpulse -= 0.5f;
    }

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        movement = false;
        joystick = gameObject.GetComponent<Joystick>();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EscButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //public void JumpButtonDown()
    //{
    //if (isGrounded)
    //{
    //    rb.AddForce(new Vector2(0, verticalImpulse), ForceMode.Impulse);
    //    Debug.Log("JumpButton");
    //}
    //}

    //public void LeftButton()
    //{
    //    movement = true;
    //    if (movement)
    //        speedX = -horizontalSpeed;
    //    Debug.Log("LeftButton");
    //}

    //public void RightButton()
    //{
    //    movement = true;
    //    if (movement)
    //        speedX = horizontalSpeed;
    //    Debug.Log("RightButton");
    //}

    //public void Stop()
    //{
    //    movement = false;
    //    speedX = 0;
    //}

    public void BootSpeed()
    {
            rb.AddForce(direction.normalized * acceleration, ForceMode.Impulse);
    }

        //void FixedUpdate()
        //    {
        //        if (joystick.Horizontal > 0.1f)
        //        {
        //            speedX = horizontalSpeed;
        //            Debug.Log("RightButton");
        //        }

        //if (Input.GetKey(KeyCode.A))  //При на удержании кнопки ////////////////// DELETE
        //{
        //    speedX = -horizontalSpeed;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    speedX = horizontalSpeed;
        //}
        //if (Input.GetKeyDown(KeyCode.W) && isGrounded)  //При от нажатии на кнопку
        //{
        //    rb.AddForce(new Vector2(0, verticalImpulse), ForceMode.Impulse);
        //    Debug.Log("SpaceBar");
        //} //////////////////////////////////////////////////////////////////////// DELETE

        //    transform.Translate(speedX, 0, 0);
        //    speedX = 0;
        //}

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Ground")
        //        isGrounded = true;
        //}
        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Ground")
        //        isGrounded = false;
        //}
    }
