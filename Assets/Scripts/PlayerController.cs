using Assets.Scripts.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Stats PlayerStats;
    public LayerMask InteractionLayer;

    private InputPlayer _inputPlayer;
    private Transform _transform;
    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private SpriteRenderer _mySpriteRenderer;
    private CharacterDirections _direction;
    private Attacker _attacker;
    private Ability _ability;
    private TrailRenderer _trailRenderer;
    private PlayerFoots _foots;

    private float dashCooldown = 0;
    private bool isDashUsed = false;
    private int isMovingHashCode;



    // Use this for initialization
    void Start ()
    {
        _inputPlayer = GetComponent<InputPlayer>();
        _transform = GetComponent<Transform>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _attacker = GetComponent<Attacker>();
        _ability = GetComponent<Ability>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _foots = GetComponentInChildren<PlayerFoots>();

        isMovingHashCode = Animator.StringToHash("IsMoving");
        switchTrailRenderer();

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

        if(_inputPlayer.Inventory)
        {
            MenuPanel.Instance.OpenClose();
        }

        updateDashCooldown();
    }

    private void updateDashCooldown()
    {
        if(isDashUsed)
        {
            dashCooldown += Time.deltaTime;
            if(dashCooldown > _trailRenderer.time)
            {
                dashCooldown = 0;
                isDashUsed = false;
                switchTrailRenderer();
            }
        }
    }

    void FixedUpdate()
    {

        //movePlayer();
        movePlayerByPhisics();

    }

    public void ControllerAttack()
    {
        _attacker.Attack(_inputPlayer.Orientation, PlayerStats.Attack);
        _myAnimator.SetBool("IsAttacking", false);
    }

    public RaycastHit2D[] Interact()
    {
        RaycastHit2D[] result;
        Debug.Log("Casting Ray");

        result = castRay(_transform.position, GetComponent<CapsuleCollider2D>().size.x, _inputPlayer.Orientation.normalized, 2f, InteractionLayer);

        Debug.Log("Casted Ray");
        return result;
    }

    private RaycastHit2D[] castRay(Vector3 transform, float radius, Vector2 orientation, float size, int layer)
    {
        //Debug.Log("transform: " + transform);
        //Debug.Log("radius: " + radius);
        //Debug.Log("orientation: " + orientation);
        //Debug.Log("size: " + size);
        //Debug.Log("layer: " + layer);

        return Physics2D.CircleCastAll(transform, radius, orientation, size, layer);
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
        else if ((_horizontal != 0 || _vertical != 0) && !isDashUsed)
        {
            force = new Vector2(_horizontal, _vertical) * PlayerStats.Speed;
            _myRigidBody.velocity = force;
        }
        
        if(_inputPlayer.Skill2 && !isDashUsed)
        {
            isDashUsed = true;
            _ability.Dash(_inputPlayer.Orientation, _myRigidBody);
            switchTrailRenderer();
        }
    }

    private void movePlayer()
    {
        Vector2 newPos;

        newPos = _transform.position + new Vector3(PlayerStats.Speed * _horizontal * Time.deltaTime,
                                                    PlayerStats.Speed * _vertical * Time.deltaTime,
                                                    0);

        _transform.position = newPos;
    }

    private void switchTrailRenderer()
    {
        if(_trailRenderer != null)
        {
            _trailRenderer.enabled = !_trailRenderer.enabled;
        }
    }

    private void walk()
    {
        if(_foots != null)
        {
            _foots.PlayWalkSound();
        }
    }
}
