﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _jumpForce = 0;
    [SerializeField] private float _inertia = 0;
    [SerializeField] private float _walljumpForce = 0;
    [SerializeField] private float _slideSpeed = 0;
    [SerializeField] private float _fallMultiplier = 0;
    [SerializeField] private float _jumpBreak = 0;
    [SerializeField] private float _dashLength = 0;
    [SerializeField] private float _dashCooldown = 0;

    [SerializeField] private Vector2 _walljumpAngle = Vector2.zero;
    [SerializeField] private Animator _ani = null;

    [SerializeField] private ParticleSystem[] _snow = null;
    [SerializeField] private ParticleSystem[] _fire = null;

    [SerializeField] private LevelUI _ui = null;

    //private InputPad _gamepad = null;

    private RaycastHit2D[] _rays = new RaycastHit2D[6]; 

    private Rigidbody2D _rig = null;

    private BoxCollider2D _collider = null;

    private SpriteRenderer _renderer = null;

    private Vector2[] _rayOrigins = new Vector2[4];

    private float _inputX = 0;
    private float _coyoteTime = 0;
    private float _coyoteReset = .4f;
    private float _jumpPressed = 0;
    private float _dashDirection = 0;
    
    private bool _inAir = false;
    private bool _onFloor = false;
    private bool _onWall = false;
    private bool _wallRight = false;
    private bool _wallLeft = false;
    private bool _jumpInitiated = false;
    private bool _dashing = false;
    private bool _dashPossible = true;
    private bool _doublejumpPossible = false;


    public ElectricObject Thunderstone = null;

    public float JumpPressed
    {
        get => _jumpPressed;
        set => _jumpPressed = value;
    }
    public float InputX
    {
        get => _inputX;
        set => _inputX = value;
    }

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _walljumpAngle = Vector2.ClampMagnitude(_walljumpAngle, 1);
        _renderer = GetComponent<SpriteRenderer>();
        for(int i=0; i < _snow.Length; i++) { _snow[i].Stop(); }
        for (int i = 0; i < _fire.Length; i++) { _fire[i].Stop(); }
    }

    private void Update()
    {
       

        //wait for coyotetime to run out before setting inAir to true
        _coyoteTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //set horizontal speeds
        var accelerate = _rig.velocity.x;
        accelerate = Mathf.MoveTowards(accelerate, _speed * _inputX, _inertia * Time.fixedDeltaTime);
        var airMovement = new Vector2(accelerate, _rig.velocity.y);
        var groundMovement = new Vector2(_inputX * _speed, _rig.velocity.y);

        //determine which speed to use
        _rig.velocity = _onFloor ? groundMovement : airMovement;

        //make Jumpheight controllable
        if (_rig.velocity.y < 0 && _rig.velocity.y > -3f && !_onWall)
        {
            _rig.velocity += Time.fixedDeltaTime * Physics2D.gravity.y * (_fallMultiplier - 1) * Vector2.up;
        }
        else if(_rig.velocity.y >= 0 && _jumpPressed != 1 && !_onWall)
        {
            _rig.velocity += Time.fixedDeltaTime * Physics2D.gravity.y * (_jumpBreak - 1) * Vector2.up;
        }

        //slow down when sliding down a wall
        if (_wallLeft && _inputX == -1 && _rig.velocity.y <= 0)
        {
            _ani.SetBool("OnWall", true);
            _rig.velocity = new Vector2(_rig.velocity.x, -_slideSpeed);
        }
        else if(_wallRight && _inputX == 1 && _rig.velocity.y <= 0)
        {
            _ani.SetBool("OnWall", true);
            _rig.velocity = new Vector2(_rig.velocity.x, -_slideSpeed);
        }

        if(!_onWall)
        _ani.SetBool("OnWall", false);


        //check for collisions with floor and rails
        CollisionCheck();

        //Dash
        if (_dashing)
            Dash();
    }

    void CollisionCheck()
    {
        //set ray origins to the bottom corners of the player collider
        _rayOrigins[0] = _collider.bounds.min;
        _rayOrigins[1] = new Vector2(_collider.bounds.max.x, _collider.bounds.min.y);
        _rayOrigins[2] = new Vector2(_collider.bounds.min.x, _collider.bounds.max.y);
        _rayOrigins[3] = _collider.bounds.max;

        //set raycasthits with 0 and 1 being floor and 2 and 3 being walls
        _rays[0] = Physics2D.Raycast(_rayOrigins[0], -Vector2.up, .12f, LayerMask.GetMask("Floor", "Walljumprail"));
        _rays[1] = Physics2D.Raycast(_rayOrigins[1], -Vector2.up, .12f, LayerMask.GetMask("Floor", "Walljumprail"));
        _rays[2] = Physics2D.Raycast(_rayOrigins[0], Vector2.left, .5f, LayerMask.GetMask("Walljumprail"));
        _rays[3] = Physics2D.Raycast(_rayOrigins[1], Vector2.right, .5f, LayerMask.GetMask("Walljumprail"));
        _rays[4] = Physics2D.Raycast(_rayOrigins[2], Vector2.left, .5f, LayerMask.GetMask("Walljumprail"));
        _rays[5] = Physics2D.Raycast(_rayOrigins[3], Vector2.right, .5f, LayerMask.GetMask("Walljumprail"));

        if (_rays[0] || _rays[1])
        {
            _doublejumpPossible = true;
            _inAir = false;
            _onFloor = true;
            _onWall = false;
            _wallLeft = false;
            _wallRight = false;
            _coyoteTime = _coyoteReset;
        }
        else if(_rays[2] || _rays[3] || _rays[4] || _rays[5])
        {
            _doublejumpPossible = true;
            _wallLeft = (_rays[2] || _rays[4]) ? true : false;
            _wallRight = (_rays[3] || _rays[5]) ? true : false;
            _onFloor = false;
            _onWall = true;
        }
        else
        {
            _onFloor = false;
            _onWall = false;
            _wallLeft = false;
            _wallRight = false;
            if(_coyoteTime <= 0)
                _inAir = true;
        }
    }

    // Jump Implementation

    public void Jump()
    {
        if (!_inAir && !_jumpInitiated)
        {
            transform.position += (Vector3)Vector2.up * .3f;
            _rig.AddForce(Vector2.up * _jumpForce * 80);
            _jumpInitiated = true;
            StartCoroutine(JumpResetRoutine());
        }
        else if (_onWall)
        {
            Walljump();
        }
        else if (_doublejumpPossible)
        {
            _rig.velocity = Vector2.right * _rig.velocity;
            _rig.AddForce(Vector2.up * _jumpForce * 60);
            _doublejumpPossible = false;
            for (int i = 0; i < _fire.Length; i++) { _fire[i].Play(); }
            StartCoroutine(DoubleJumpRoutine());
        }
        else StartCoroutine(BufferjumpRoutine());
    }

    // Walljump Implementation

    void Walljump()
    {
        if (_rays[2] || _rays[4])
        {
            _rig.velocity = Vector2.zero;
            _rig.AddForce(_walljumpAngle * _walljumpForce * 80);
        }
        else if (_rays[3] || _rays[5])
        {
            _rig.velocity = Vector2.zero;
            _rig.AddForce(new Vector2(-_walljumpAngle.x, _walljumpAngle.y) * _walljumpForce * 80);
        }
    }

    // Icedash Implementation
    public void StartDash(float direction)
    {
        if(_dashPossible && direction != 0)
        {
            _dashPossible = false;
            _renderer.enabled = false;
            for (int i = 0; i < _snow.Length; i++) { _snow[i].Play(); }
            _dashing = true;
            _dashDirection = direction * _dashLength;
            StartCoroutine(DashRoutine());
        }
    }

    void Dash() => _rig.velocity = Vector2.right * _dashDirection;

    //Remove Thunderstone
    public void Electric()
    {
        if (Thunderstone)
            Thunderstone.GetComponent<ElectricObject>().DrawLine();
    }
    

    // Bufferjump Implementation
    private IEnumerator BufferjumpRoutine()
    {
       yield return new WaitForSeconds(.1f);
        if (_onFloor)
        {
            transform.position += (Vector3)Vector2.up * .1f;
            _rig.AddForce(Vector2.up * _jumpForce * 80);
        }
    }

    //prevent Coyotejump from fucking with the gameflow
    private IEnumerator JumpResetRoutine()
    {
        yield return new WaitForSeconds(.45f);
        _jumpInitiated = false;
    }

    private IEnumerator DoubleJumpRoutine()
    {
        yield return new WaitForSeconds(.4f);
        for (int i = 0; i < _fire.Length; i++) { _fire[i].Stop(); }
    }

    private IEnumerator DashRoutine()
    {
        yield return new WaitForSeconds(.3f);
        _dashing = false;
        _renderer.enabled = true;
        for (int i = 0; i < _snow.Length; i++) { _snow[i].Stop(); }

        yield return new WaitForSeconds(_dashCooldown -.3f);
        _dashPossible = true;
    }
}
