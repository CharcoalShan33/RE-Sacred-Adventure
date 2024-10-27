using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerActions _playActions;

    private Animator _anim;
    Rigidbody2D _rig;

    [SerializeField]
    private float _speed;

    Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        _playActions = new PlayerActions();
        _rig = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _playActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
       float xInput= _playActions.PlayerLevel.Movement.ReadValue<Vector2>().x;

       float yInput= _playActions.PlayerLevel.Movement.ReadValue<Vector2>().y;

        movement = new Vector2(xInput, yInput).normalized;

        
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
        _rig.velocity = movement * _speed;

        
    }
}
