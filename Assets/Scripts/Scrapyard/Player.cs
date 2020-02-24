using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("Player")] public Actor ActorObject;

    private InputPad _pad = null;

    private Rigidbody2D _rig;
    
    //Raycast
    private RaycastHit2D _floorHit1;
    private RaycastHit2D _floorHit2;
    private RaycastHit2D _leftWall;
    private RaycastHit2D _rightWall;
    //private Transform _rayOrigin = null;
    public Transform RayOrigin1 = null;
    public Transform RayOrigin2 = null;
    public Transform RayL = null;
    public Transform RayR = null;

    
    //movement Input Value
    private float _move = 0;
    private Vector2 _stickAxis = Vector2.zero;
    public Vector3 InactivityPos = Vector3.zero;
    
    private bool _timeStopped = false; //used by time ability
    private bool _flipped = false;
    private Camera _cam = null; //for post processing

    private float _cooldown = 0;

    //references
    public GameObject RollObj = null;
    public Transform RollLoc = null;
    public Roll RollRef = null;
    public PostProcessVolume InvertedColour = null;
    public ParticleSystem BGParticles = null;
    public ParticleSystem FGParticles = null;
    public ElectricObject Thunderstone = null;
    private float _lateJumpReset = 0;
    
    // ---------- Unity Events ----------
    
    private void Awake()
    {
        _pad = new InputPad();
        // ---------- Actual Gamepad ----------
        _pad.Gameplay.Run.performed += Stick => _stickAxis = Stick.ReadValue<Vector2>();
        _pad.Gameplay.Run.canceled += Stick => _stickAxis = Vector2.zero;
        _pad.Gameplay.Jump.performed += Button => Jump();
        _pad.Gameplay.Roll.performed += RollButton => Roll();
        _pad.Gameplay.Ice.performed += IceButton => Ice();
        _pad.Gameplay.Electric.performed += ElButton => Electric();
        _pad.Gameplay.Time.performed += TimeButton => TimeStop();
        //_pad.Gameplay.Time.canceled += TimeButton => TimeRestart();
        
        // ---------- Keyboard ----------
        _pad.Gameplay.RunL.performed += ArrL => AccelerateLeft();
        _pad.Gameplay.RunL.canceled += ArrL => Decelerate();
        _pad.Gameplay.RunR.performed += ArrR => AccelerateRight();
        _pad.Gameplay.RunR.canceled += ArrR => Decelerate();

        _pad.Gameplay.Jump2.performed += JumpKey => Jump();
        _pad.Gameplay.Roll2.performed += RollKey => Roll();
        _pad.Gameplay.Time2.performed += TimeKey => TimeStop();
        _pad.Gameplay.Ice2.performed += IceKey => Ice();
        _pad.Gameplay.Electric2.performed += ElKey => Electric();
    }

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _cam = UnityEngine.Camera.main.GetComponent<Camera>();
        ActorObject.Rolling = false;
    }

    private void FixedUpdate()
    {
        Collisions();

        if (_leftWall || _rightWall)
        {
            _lateJumpReset = ActorObject.CoyoteTime;
            _cam.CloseToWall = true;
            if(!ActorObject.JumpInitiated)
                ActorObject.Jumping = false;
        }
        else
        {
            _cam.CloseToWall = false;
        }
        
        if ((_floorHit1 || _floorHit2) && !ActorObject.JumpInitiated)
        {
            ActorObject.Jumping = false;
            _lateJumpReset = ActorObject.CoyoteTime;
        }
        _lateJumpReset -= Time.deltaTime;
        if (_lateJumpReset <= 0)
        {
            ActorObject.Jumping = true;
        }
        
        var vel = _rig.velocity;

        float groundAcceleration = 40f; // acceleration on ground
        float airAcceleration = 35f; // acceleration in air
        float acceleration = Mathf.Lerp(airAcceleration, groundAcceleration, _floorHit1 ? 1 : 0);
        
        vel.x = Mathf.MoveTowards(vel.x, _move * ActorObject.Speed,
            acceleration * Time.fixedDeltaTime);

        _rig.velocity = vel;
        
        if (_rig.velocity.y < 0 && _rig.velocity.y > -3f)
        {
            _rig.velocity += Time.fixedDeltaTime * Physics2D.gravity.y * (ActorObject.FallMultiplier - 1) * Vector2.up;
        }
    }

    void Update()
    {
        if (_stickAxis.x > .5f)
            _move = 1;
        else if (_stickAxis.x < -.5f)
            _move = -1;
        else
            _move = 0;
        
        //flip direction
        if (_rig.velocity.x > 0)
            _flipped = false;
        else if (_rig.velocity.x < 0)
            _flipped = true;

        _cooldown -= Time.deltaTime;
        if(_cooldown <= 0)
            TimeRestart();
       // _rayOrigin = (_flipped ? RayOrigin1 : RayOrigin2);
    }
    
    // ---------- Custom Events ----------
    
    private void OnEnable() => _pad.Gameplay.Enable();
    private void OnDisable() => _pad.Gameplay.Disable();

    void Collisions()
    {
        _floorHit1 = Physics2D.Raycast(RayOrigin1.position, -Vector2.up, .15f, LayerMask.GetMask("Floor", "Walljumprail"));
        _floorHit2 = Physics2D.Raycast(RayOrigin2.position, -Vector2.up, .15f, LayerMask.GetMask("Floor", "Walljumprail"));
        _leftWall = Physics2D.Raycast(RayL.position, Vector2.left, .1f, LayerMask.GetMask("Walljumprail"));
        _rightWall = Physics2D.Raycast(RayR.position, Vector2.right, .1f, LayerMask.GetMask("Walljumprail"));
    }

    void AccelerateLeft() => _stickAxis = new Vector2(-1,0);
    void AccelerateRight() => _stickAxis = new Vector2(1,0);
    void Decelerate() => _stickAxis = Vector2.zero;

    public void Jump()
    {
        if (!ActorObject.Rolling)
        {
            if (!ActorObject.Jumping)
            {
                if (_leftWall || _rightWall)
                {
                    WallJump();
                }
                else
                {
                    gameObject.transform.position += Vector3.up * .4f;
                    _rig.AddForce(new Vector2(_rig.velocity.x, ActorObject.JumpHeight * 80));
                }
                ActorObject.JumpInitiated = true;
                StartCoroutine(ActorObject.JumpCooldown());
                ActorObject.Jumping = true;
            }
            else StartCoroutine(EarlyJumpRoutine());

            if (_rig.velocity.y >= 0f)
                _rig.velocity += Time.deltaTime * Physics2D.gravity.y * (ActorObject.JumpMultiplier - 1) * Vector2.up;
        }
        else
        {
                ManageRoll(false, RollLoc);
                RollObj.SetActive(false);
        }
    }

    void WallJump()
    {
        if (_leftWall && _stickAxis.x > -.1f)
        {
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(_rig.velocity.x + ActorObject.JumpHeight * 50, ActorObject.JumpHeight * 70));
        }
        else if (_rightWall && _stickAxis.x < .1f)
        {
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(_rig.velocity.x - ActorObject.JumpHeight * 50, ActorObject.JumpHeight * 70));
        }
    }
    
    //---------- roll ----------
    public void ManageRoll(bool _rl, Transform locReset)
    {
        _rig.transform.position = locReset.transform.position + Vector3.up * .5f;
            ActorObject.Rolling = _rl;
    }

    void Roll()
    {
        if(!ActorObject.Rolling){
            RollObj.SetActive(true);
            ActorObject.Rolling = true;
            RollRef.SetActivity(true, _move, _rig.velocity.magnitude);
            _rig.transform.position = InactivityPos;
        }
    }

    //---------- freeze water ----------
    void Ice()
    {
        var abilityObj = Instantiate(ActorObject.ice, transform.position, Quaternion.identity);
    }
    
    //---------- summon lightning ----------

    void Electric()
    {
        if(Thunderstone)
            Thunderstone.GetComponent<ElectricObject>().DrawLine();
    }

    //---------- stop time ----------
    void TimeStop()
    {
        if (_cooldown <= 0)
        {
            ActorObject.Lightweight = true;
            InvertedColour.weight = 1;
            BGParticles.Pause();
            FGParticles.Pause();
            _cooldown = ActorObject.Cooldown;
        }
    }

    void TimeRestart()
    {
        InvertedColour.weight = 0;
        ActorObject.Lightweight = false;
        if(BGParticles.isPaused)
            BGParticles.Play();
        if(FGParticles.isPaused)
            FGParticles.Play();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!ActorObject.Lightweight)
        {
            if (other.gameObject.GetComponent<AirObject>())
            {
                var box = other.gameObject.GetComponent<AirObject>();
                box.SwapToFall();
            }
        }
    }
    
    //---------- bufferjump implementation ----------
    private IEnumerator EarlyJumpRoutine()
    {
        yield return new WaitForSeconds(.1f);
        if (_floorHit1 || _floorHit2)
        {
            gameObject.transform.position += Vector3.up * .4f;
            _rig.AddForce(new Vector2(_rig.velocity.x, ActorObject.JumpHeight * 80));
            ActorObject.Jumping = true;
        }
    }

    //---------- 1s Cooldown for Everything ----------

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(1f);
    }
}
