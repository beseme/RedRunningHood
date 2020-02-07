using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class KeyboardInput : MonoBehaviour
{
    public Actor Player;
    
    private Rigidbody2D _rig;
    
    //Raycast
    private RaycastHit2D _floorHit;
    private RaycastHit2D _leftWall;
    private RaycastHit2D _rightWall;
    public Transform RayOrigin = null;
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
    public GameObject ElectricObject = null;
    private float _lateJumpReset = 0;
    
    //Unity Events
    
    private void Awake()
    {
    }

    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _cam = UnityEngine.Camera.main.GetComponent<Camera>();
        InvertedColour.enabled = false;
    }

    private void FixedUpdate()
    {
        _floorHit = Physics2D.Raycast(RayOrigin.position, -Vector2.up, .15f, LayerMask.GetMask("Floor", "Walljumprail"));
        _leftWall = Physics2D.Raycast(RayL.position, Vector2.left, .1f, LayerMask.GetMask("Walljumprail"));
        _rightWall = Physics2D.Raycast(RayR.position, Vector2.right, .1f, LayerMask.GetMask("Walljumprail"));
        if (_leftWall || _rightWall)
        {
            _lateJumpReset = Player.CoyoteTime;
            _cam.CloseToWall = true;
            if(!Player.JumpInitiated)
                Player.Jumping = false;
        }
        else
        {
            _cam.CloseToWall = false;
        }
        
        if (_floorHit && !Player.JumpInitiated)
        {
            Player.Jumping = false;
            _lateJumpReset = Player.CoyoteTime;
        }
        _lateJumpReset -= Time.deltaTime;
        if (_lateJumpReset <= 0)
        {
            Player.Jumping = true;
        }
        
        var vel = _rig.velocity;

        float groundAcceleration = 80f; // acceleration on ground
        float airAcceleration = 60f; // acceleration in air
        float acceleration = Mathf.Lerp(airAcceleration, groundAcceleration, _floorHit ? 1 : 0);
        
        vel.x = Mathf.MoveTowards(vel.x, _move * Player.Speed,
            acceleration * Time.fixedDeltaTime);

        _rig.velocity = vel;
        
        if (_rig.velocity.y < 0 && _rig.velocity.y > -3f)
        {
            _rig.velocity += Time.fixedDeltaTime * Physics2D.gravity.y * (Player.FallMultiplier - 1) * Vector2.up;
        }
    }

    void Update()
    {
        _move = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump"))
            Jump();
        
        if(Input.GetButtonDown("Roll"))
            Roll();
        
        if(Input.GetButtonDown("Time"))
            TimeStop();
        
        if(Input.GetButtonDown("Electric"))
            Electric();
        
        if(Input.GetButtonDown("Freeze"))
            Ice();
        
        //if(Input.GetButton("Fire"))
        
        //flip direction
        if (_rig.velocity.x > 0)
            _flipped = false;
        else if (_rig.velocity.x < 0)
            _flipped = true;

        _cooldown -= Time.deltaTime;
        if(_cooldown <= 0)
            TimeRestart();
    }
    
    //Custom Events

    void Jump()
    {
        if (!Player.Rolling)
        {
            if (!Player.Jumping)
            {
                if (_leftWall)
                {
                    _rig.velocity = new Vector2(_rig.velocity.x, 0);
                    _rig.AddForce(new Vector2(_rig.velocity.x + Player.JumpHeight * 50, Player.JumpHeight * 70));
                }
                else if (_rightWall)
                {
                    _rig.velocity = new Vector2(_rig.velocity.x, 0);
                    _rig.AddForce(new Vector2(_rig.velocity.x - Player.JumpHeight * 50, Player.JumpHeight * 70));
                }
                else
                {
                    gameObject.transform.position += Vector3.up * .4f;
                    _rig.AddForce(new Vector2(_rig.velocity.x, Player.JumpHeight * 80));
                }

                Player.JumpInitiated = true;
                StartCoroutine(Player.JumpCooldown());
                Player.Jumping = true;
            }
            else StartCoroutine(EarlyJump());

            if (_rig.velocity.y >= 0f)
                _rig.velocity += Time.deltaTime * Physics2D.gravity.y * (Player.JumpMultiplier - 1) * Vector2.up;
        }
        else
        {
            ManageRoll(false, RollLoc);
            RollObj.SetActive(false);
        }
    }
//---------- bufferjump implementation ----------
    private IEnumerator EarlyJump()
    {
        yield return new WaitForSeconds(.1f);
        if (_floorHit)
        {
            gameObject.transform.position += Vector3.up * .4f;
            _rig.AddForce(new Vector2(_rig.velocity.x, Player.JumpHeight * 80));
            Player.Jumping = true;
        }
    }
    
    //---------- roll ----------
    public void ManageRoll(bool _rl, Transform locReset)
    {
        _rig.transform.position = locReset.transform.position + Vector3.up * .5f;
        Player.Rolling = _rl;
    }

    void Roll()
    {
        if(!Player.Rolling){
            RollObj.SetActive(true);
            Player.Rolling = true;
            RollRef.SetActivity(true, _move, _rig.velocity.magnitude);
            _rig.transform.position = InactivityPos;
        }
    }

    //---------- freeze water ----------
    void Ice()
    {
        var abilityObj = Instantiate(Player.ice, transform.position, Quaternion.identity);
    }
    
    //---------- summon lightning ----------

    void Electric()
    {
        if(ElectricObject)
            ElectricObject.GetComponent<ElectricObject>().DrawLine();
    }

    //---------- stop time ----------
    void TimeStop()
    {
        if (_cooldown <= 0)
        {
            Player.Lightweight = true;
            InvertedColour.enabled = true;
            BGParticles.Pause();
            FGParticles.Pause();
            _cooldown = Player.Cooldown;
        }
    }

    void TimeRestart()
    {
        InvertedColour.enabled = false;
        Player.Lightweight = false;
        if(BGParticles.isPaused)
            BGParticles.Play();
        if(FGParticles.isPaused)
            FGParticles.Play();
    }
    
    //---------- 1s Cooldown for Everything ----------

    private IEnumerator CL()
    {
        yield return new WaitForSeconds(1f);
    }
}
