using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerMovementController : MonoBehaviour
{
    public VariableJoystick joystick;
    public float Speed = 0.3f;
    public float JumpForce = 1f;
    public float maxSpeed = 20f;
    public float Boost = 1000f;
    public bool isLeft;
    public Sprite s_boostLeft;
    public Sprite s_boostRight;
    public Image BoostButtonImage;


    //даем возможность выбрать тэг пола. 
    //так же убедитесь что ваш Player сам не относится к даному слою.  

    //!!!!Нацепите на него нестандартный Layer, например Player!!!! 
    public LayerMask GroundLayer = 1; // 1 == "Default" 

    public Rigidbody _rb;
    private CapsuleCollider _collider; // теперь прийдется использовать CapsuleCollider 
                                       //и удалите бокс коллайдер если он есть 

    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);

            //создаем невидимую физическую капсулу и проверяем не пересекает ли она обьект который относится к полу 

            //_collider.bounds.size.x / 2 * 0.9f -- эта странная конструкция берет радиус обьекта. 
            // был бы обязательно сферой -- брался бы радиус напрямую, а так пишем по-универсальнее 

            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
            // если можно будет прыгать в воздухе, то нужно будет изменить коэфициент 0.9 на меньший. 
        }
    }

    private Vector3 _movementVector
    {
        get
        {

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    private Vector3 _movementVectorJoystic
    {
        get
        {

            var horizontal = joystick.Horizontal;
            //var vertical = joystick.Vertical;

            return new Vector3(horizontal, 0.0f, 0.0f);
        }
    }


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();

        //т.к. нам не нужно что бы персонаж мог падать сам по-себе без нашего на то указания. 
        //то нужно заблочить поворот по осях X и Z 
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        //  Защита от дурака 
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
    }

    void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
        directionDetecter();
    }

    void directionDetecter()
    {
        if (joystick.Horizontal > 0 | _movementVector.x > 0)
        {
            isLeft = false;
            BoostButtonImage.sprite = s_boostRight;
        }
        if (joystick.Horizontal < 0 | _movementVector.x < 0)
        {
            isLeft = true;
            BoostButtonImage.sprite = s_boostLeft;
        }
    }

    private void SpeedControl()
    {
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }

    private void MoveLogic()
    {
        // т.к. мы сейчас решили использовать физическое движение снова, 
        // мы убрали и множитель Time.fixedDeltaTime 
        if (_rb.velocity.magnitude < maxSpeed)
        {
            _rb.AddForce(_movementVector * Speed, ForceMode.Impulse);
            _rb.AddForce(_movementVectorJoystic * Speed, ForceMode.Impulse); 
        }
    }

    private void JumpLogic()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        if (_isGrounded && (joystick.Vertical > 0.5f))
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
    
    public void BootSpeed()
    {
        if (!isLeft) //right
        {
            _rb.AddForce(Vector3.right * Boost, ForceMode.Impulse);
            //_rb.AddForce(-_movementVectorJoystic * Boost, ForceMode.Impulse);
        }
        if (isLeft) //left
        {
            _rb.AddForce(Vector3.left * Boost, ForceMode.Impulse);
            //_rb.AddForce(_movementVectorJoystic * Boost, ForceMode.Impulse);
        }
    }

}
