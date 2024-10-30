using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _playActions;

    private Animator _anim;
    Rigidbody2D _rig;

    [SerializeField, Range(80, 150)]
    private float _speed;

    [Range(80,150)]
    private float _maxSpeed = 95f;

    Vector2 movement;

    [SerializeField, Range(1, 5)]
    private float attackRate;

    private float lastAttack; // shows the time value when the button is pressed.

    float time;
    // Start is called before the first frame update
    void Awake()
    {
        _playActions = new PlayerActions();
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        _playActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
       float xInput= _playActions.PlayerLevel.Movement.ReadValue<Vector2>().x;

       float yInput= _playActions.PlayerLevel.Movement.ReadValue<Vector2>().y;

        movement = new Vector2(xInput, yInput).normalized;

            HitObject();
          _anim.SetFloat("moveX", movement.x);
          _anim.SetFloat("moveY", movement.y);
        
        if (xInput != 0|| yInput !=0)
        {
            _anim.SetFloat("lastX", xInput);
            _anim.SetFloat("lastY", yInput);
        }


    }


    private void FixedUpdate()
    {
        _rig.velocity = movement * _speed * Time.fixedDeltaTime;

        
    }

    public void HitObject()
    {
        float decreaseTime = Time.time - lastAttack;// the difference between current runtine and the last known value 
        if (_playActions.PlayerLevel.Hit.triggered && decreaseTime > attackRate)
        {
            lastAttack = Time.time;
            _anim.SetTrigger("Hit Target");
            
        }
    }

    public void StopMoving()
    {
        _speed = 0f;
    }

    public void Moving()
    {
        _speed = _maxSpeed;
    }
}
