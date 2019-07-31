using Assets.Scripts.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stats))]
public class PlayerController : MonoBehaviour {

    private InputPlayer _inputPlayer;
    private Transform _transform;
    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private SpriteRenderer _mySpriteRenderer;
    private CharacterDirections _direction;
    private Stats _playerStats;
    private Attacker _attacker;

    private int isMovingHashCode;



    // Use this for initialization
    void Start ()
    {
        _inputPlayer = GetComponent<InputPlayer>();
        _transform = GetComponent<Transform>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _playerStats = GetComponent<Stats>();
        _attacker = GetComponent<Attacker>();

        isMovingHashCode = Animator.StringToHash("IsMoving");
    }

    // Update is called once per frame
    void Update ()
    {
        _horizontal = _inputPlayer.X_Axis;
        _vertical = _inputPlayer.Y_Axis;
        getDirection();

        if(_inputPlayer.Attack)
        {
            _myAnimator.SetBool("IsAttacking", true);
            //controllerAttack();
        }
    }

    void FixedUpdate()
    {

        //movePlayer();
        movePlayerByPhisics();

    }

    private void getDirection()
    {
        /*
        if (_horizontal < 0 && Mathf.Abs(_vertical) < Mathf.Abs(_horizontal))
        {
            _mySpriteRenderer.flipX = true;
        }
        else if (_horizontal > 0)
        {
            _mySpriteRenderer.flipX = false;
        }
        */

        /*
        if (_horizontal != 0 || _vertical != 0)
        {
            _myAnimator.SetFloat("X", _horizontal);
            _myAnimator.SetFloat("Y", _vertical);
            _myAnimator.SetBool(isMovingHashCode, true);
        }
        else
        {
            _myAnimator.SetBool(isMovingHashCode, false);
        }
        */

        if (_horizontal != 0 || _vertical != 0)
        {
            _myAnimator.SetFloat("X", _inputPlayer.Orientation.x);
            _myAnimator.SetFloat("Y", _inputPlayer.Orientation.y);
            _myAnimator.SetBool(isMovingHashCode, true);
        }
        else
        {
            _myAnimator.SetBool(isMovingHashCode, false);
        }
    }

    private void movePlayerByPhisics()
    {
        Vector2 force;

        if (_myAnimator.GetBool("IsAttacking"))
        {
            _myRigidBody.velocity = Vector2.zero;
        }
        else
        {

            force = new Vector2(_horizontal, _vertical) * _playerStats.Speed;
            _myRigidBody.velocity = force;
        }
    }

    private void movePlayer()
    {
        Vector2 newPos;

        newPos = _transform.position + new Vector3(_playerStats.Speed * _horizontal * Time.deltaTime,
                                                    _playerStats.Speed * _vertical * Time.deltaTime,
                                                    0);

        _transform.position = newPos;
    }

    public void ControllerAttack()
    {
        _attacker.Attack(_inputPlayer.Orientation, _playerStats.Attack);
        _myAnimator.SetBool("IsAttacking", false);
    }
}
