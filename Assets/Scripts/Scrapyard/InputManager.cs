using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.Rendering.PostProcessing;

public class InputManager : MonoBehaviour
{
    //Objects and Physics
    private Rigidbody2D _rig;
    [SerializeField] private GameObject _roll;
    public PhysicsMaterial2D _drag = null;
    public GameObject ice;
    
    //float values
    private float _fallMultiplier = 3f;
    private float _jumpMultiplier = 4;
    private float _move;
    [SerializeField] private float _jumpHeight = 0;
    [SerializeField] private float _speed = 0;
    [SerializeField] private float _railFriction = 0;
    
    //Vectors and Transforms
    private Vector2 _stickAxis;
    private Vector3 _dir = Vector3.zero;
    [SerializeField] private Vector3 _inactive;
    public Transform _rollLoc;
    public Transform _rayOrigin = null;
    public Transform _leftRayOrigin = null;
    public Transform _rightRayOrigin = null;
    
    //Raycast
    private RaycastHit2D _floorHit;
    private RaycastHit2D _leftWall;
    private RaycastHit2D _rightWall;
    
    //boolean
    public bool _rolling;
    public bool _jumping;
    private bool _jumpInitiated;
    private bool _timeStopped;
    

    //references
    [SerializeField] private Roll _rollRef;
    public InputPad _pad;
    private Camera _cam = null;
    [SerializeField]
    private PostProcessVolume _invertedColour;
    [SerializeField]
    private ParticleSystem _backGround;
    [SerializeField]
    private ParticleSystem _foreGround;


    // Start is called before the first frame update
    void Awake()
    {
        _pad = new InputPad();

        _pad.Gameplay.Run.performed += Stick => _stickAxis = Stick.ReadValue<Vector2>();
        _pad.Gameplay.Run.canceled += Stick => _stickAxis = Vector2.zero;

        _pad.Gameplay.Jump.performed += Button => Jump();

        _pad.Gameplay.Roll.performed += RollButton => Roll();

        _pad.Gameplay.Ice.performed += IceButton => Ice();
        
        _pad.Gameplay.Time.performed += TimeButton => TimeStop();
    }

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _rolling = false;
        _cam = UnityEngine.Camera.main.GetComponent<Camera>();
    }

    void Jump()
    {
        if (!_rolling)
        {
            if (!_jumping)
            {
                if (_leftWall)
                {
                    _rig.velocity = new Vector2(_rig.velocity.x,0);
                    _rig.AddForce(new Vector2(_rig.velocity.x + _jumpHeight * 50, _jumpHeight * 70));
                }
                else if (_rightWall)
                {
                    _rig.velocity = new Vector2(_rig.velocity.x,0);
                    _rig.AddForce(new Vector2(_rig.velocity.x - _jumpHeight * 50, _jumpHeight * 70));
                }
                else
                {
                    gameObject.transform.position += Vector3.up * .4f;
                    _rig.AddForce(new Vector2(_rig.velocity.x, _jumpHeight * 80));
                }

                _jumpInitiated = true;
                StartCoroutine(JumpCooldown());
                _jumping = true;
            }

            if (_rig.velocity.y >= 0f)
                _rig.velocity += Vector2.up * Physics2D.gravity.y * (_jumpMultiplier - 1) * Time.deltaTime;
        }
        else
        {
            ManageRoll(false, _rollLoc);
            _roll.SetActive(false);
        }
    }

    void Roll()
    {
        if(!_rolling){
        _roll.SetActive(true);
        _rolling = true;
        _rollRef.SetActivity(true, _move, _rig.velocity.magnitude);
        _rig.transform.position = _inactive;
        }
}

    void Ice()
    {
        GameObject curProjectile = Instantiate(ice, transform.position, Quaternion.identity);
    }

    void TimeStop()
    {
        _timeStopped = true;
        _invertedColour.enabled = true;
        _backGround.Pause();
        _foreGround.Pause(); 
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "AirObject" && !_timeStopped)
        {
            AirObject _box = collision.gameObject.GetComponent<AirObject>();
            _box.SwapToFall();
        }
    }
    void RunLeft()
    {
        _rig.velocity = -_dir;
    }

    void RunRight()
    {
        _rig.velocity = _dir;
    }

    private void OnEnable()
    {
        _pad.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _pad.Gameplay.Disable();
    }

    public void ManageRoll(bool _rl, Transform locReset)
    {
        _rig.transform.position = locReset.transform.position + new Vector3(0,.5f,0);
        _rolling = _rl;
    }

    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(.1f);
        _jumpInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_stickAxis.x > 0)
            _move = _stickAxis.magnitude;
        else
            _move = -_stickAxis.magnitude;
    }

    void FixedUpdate()
    {
        _floorHit = Physics2D.Raycast(_rayOrigin.position, -Vector2.up, .03f, LayerMask.GetMask("Floor"));
        _leftWall = Physics2D.Raycast(_leftRayOrigin.position, Vector2.left, .05f, LayerMask.GetMask("Walljumprail"));
        _rightWall = Physics2D.Raycast(_rightRayOrigin.position, Vector2.right, .05f, LayerMask.GetMask("Walljumprail"));
        if (_leftWall || _rightWall)
        {
            _drag.friction = _railFriction;
            _cam.CloseToWall = true;
            if(!_jumpInitiated)
            _jumping = false;
        }
        else
        {
            _cam.CloseToWall = false;
            _drag.friction = 0f;
        }
        if (_floorHit && !_jumpInitiated)
            _jumping = false;

        var vel = _rig.velocity;

        // cool shit
        float groundAcceleration = 40f; // acceleration on ground
        float airAcceleration = 35f; // acceleration in air
        float acceleration = Mathf.Lerp(airAcceleration, groundAcceleration, _floorHit ? 1 : 0);
        
        vel.x = Mathf.MoveTowards(vel.x, _move * _speed,
            acceleration * Time.fixedDeltaTime);

        _rig.velocity = vel;
        
        if (_rig.velocity.y < 0 && _rig.velocity.y > -3f)
        {
            _rig.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
    
}
