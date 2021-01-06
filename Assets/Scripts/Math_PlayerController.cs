using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//эта строчка гарантирует что наш скрипт не завалится ести на плеере будет отсутствовать компонент Rigidbody
[RequireComponent(typeof(Rigidbody))]

public class Math_PlayerController : MonoBehaviour
{
    // т.к. логика движения изменилась мы выставили меньшее и более стандартное значение
    public float Speed = 5f;

    public float JumpForce = 300f;

    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    private Rigidbody _rb;
    private float moveHorizontal;
    public Animator animator;
    public GameObject Player;
    public VariableJoystick joystick;
    public float TurnTime = 0.1f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        //обратите внимание что все действия с физикой 
        //желательно делать в FixedUpdate, а не в Update
        JumpLogic();

        // в даном случае допустимо использовать это здесь, но можно и в Update.
        // но раз уж вызываем здесь, то 
        // двигать будем используя множитель fixedDeltaTimе 
        MovementLogic();

        directionDetecter();

        animator.SetFloat("HorizontalVelosity", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    void directionDetecter()
    {



        //if (moveHorizontal > 0)
        //{
        //    Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        //}
        //else
        //{
        //    animator.SetBool("isWalking", false);
        //}

        //if (moveHorizontal < 0)
        //{
        //    Player.transform.rotation = Quaternion.Euler(0, -90, 0);
        //}
    }

        private void MovementLogic()
    {
        float horiz = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector3(horiz, 0, 0) * Speed * Time.fixedDeltaTime;

        //moveHorizontal = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveVertical, 0.0f, Mathf.Abs(moveHorizontal));

        //// что бы скорость была стабильной в любом случае
        //// и учитывая что мы вызываем из FixedUpdate мы умножаем на fixedDeltaTimе
        //transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                // Обратите внимание что я делаю на основе Vector3.up а не на основе transform.up
                // если наш персонаж это шар -- его up может быть в том числе и вниз и влево и вправо. 
                // Но нам нужен скачек только вверх! Потому и Vector3.up
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
