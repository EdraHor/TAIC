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
    //public float acceleration;
    public VariableJoystick variableJoystick;
    public bool isLeft;
    private Transform Player;
    private int lastX;

    public void harder()
    {
        JoystickPlayerExample.verticalImpulse -= 0.5f;
    }



    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        //movement = false;
        joystick = gameObject.GetComponent<Joystick>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EscButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



    //public void BootSpeed()
    //{
    //    if (isLeft)
    //    {
    //        direction.y *= -1;
    //        rb.AddForce(-direction.normalized * acceleration, ForceMode.Impulse);
    //        direction.y *= -1;
    //    }
    //    else
    //    {
    //        rb.AddForce(direction.normalized * acceleration, ForceMode.Impulse);
    //    }
    //}


    private void FixedUpdate()
    {
        if (Player)
        {
            int currentX = Mathf.RoundToInt(Player.position.x);
            if (currentX > lastX) isLeft = false;
            else if (currentX < lastX) isLeft = true;

            lastX = Mathf.RoundToInt(Player.position.x);
        }
    }

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
