using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //objects and physics
    [SerializeField]
    private GameObject _self;
    [SerializeField]
    private Rigidbody2D _player;
    [SerializeField]
    private GameObject _roll;

    //movement
    private Vector2 _direction;
    public Transform _rollMVNT;
    [SerializeField]
    private Vector3 _inactive;
    private RaycastHit2D _floorHit;
    private RaycastHit2D _wallHitLeft;
    private RaycastHit2D _wallHitRight;
    [SerializeField]
    private Transform _rayOrigin;
    [SerializeField]
    private Transform _rayLeft;
    [SerializeField]
    private Transform _rayRight;

    //numbers
    [SerializeField]
    private float _speed;
    private float _accelerate;
    private float _speedReset;
    [SerializeField]
    private float _jumpHeight;
    private float _fallMultiplier = 3f;
    private float _jumpMultiplier = 4;

    //bools
    [SerializeField]
    private bool _isJumping;
    private bool _dashing;
    public bool _rolling;

    //misc
    [SerializeField]
    private Roll _rollRef;
    [SerializeField]
    private PhysicsMaterial2D _drag;

    public Camera Cam;




    // Start is called before the first frame update
    void Start()
    {
        _isJumping = false;
        _rolling = false;
        //_inactive = new Vector3(9, -33,0);
        _speedReset = _speed;
        Cam = UnityEngine.Camera.main.GetComponent<Camera>();
    }

   

    public void ManageRoll(bool _rl, Transform locReset)
    {
        _player.transform.position = locReset.transform.position + new Vector3(0,.5f,0);
        _rolling = _rl;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" && _dashing && Input.GetKey(KeyCode.LeftArrow)) //roll when hitting floor from dash
        {
            _isJumping = false;
            _dashing = false;
            _roll.SetActive(true);
            _rolling = true;
            _rollRef.SetActivity(true, -1, _player.velocity.magnitude);
            _player.transform.position = _inactive;
        }
        else if (collision.gameObject.tag == "floor" && _dashing && Input.GetKey(KeyCode.RightArrow))
        {
            _isJumping = false;
            _dashing = false;
            _roll.SetActive(true);
            _rolling = true;
            _rollRef.SetActivity(true, 1, _player.velocity.magnitude);
            _player.transform.position = _inactive;
        }
        else if (collision.gameObject.tag == "wall") //walljump
            _isJumping = false; _dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rolling)
        {
        //move left and right
        if (Input.GetKey(KeyCode.RightArrow))
        {
                _accelerate += Time.deltaTime * .5f;
                if(_speed <= 10)
                     _speed += _accelerate;
                _direction.x += _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
                _accelerate += Time.deltaTime * .5f;
                if(_speed <= 10)
                     _speed += _accelerate;
                _direction.x -= _speed;
        }
            else
            {
                _direction.x = 0;
                _speed = _speedReset;
                _accelerate = 0;
            }

            //jump       
            if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _player.transform.position = _player.transform.position + new Vector3(0, .04f, 0);
            _isJumping = true;
            _player.AddForce(new Vector2(_player.velocity.x, _jumpHeight * 80));
        }
        if (_player.velocity.y < 0 && _player.velocity.y > -3f)
        {
            _player.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_player.velocity.y >= 0 && !Input.GetKey(KeyCode.Space))
            _player.velocity += Vector2.up * Physics2D.gravity.y * (_jumpMultiplier - 1) * Time.deltaTime;
        else if (_player.velocity.y < -20f)
            _player.velocity -= Vector2.up * Physics2D.gravity.y; //prevents infinite downward speed


        //dash
        if (Input.GetKey(KeyCode.LeftShift) && !_dashing && _isJumping)
        {
            if (_player.velocity.y < 0)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    _dashing = true;
                    _player.AddForce(new Vector2(200, 500));
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    _dashing = true;
                    _player.AddForce(new Vector2(-200, 500));
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    _dashing = true;
                    _player.AddForce(new Vector2(200, 0));
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    _dashing = true;
                    _player.AddForce(new Vector2(-200, 0));
                }
            }
        }

        //roll
        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isJumping)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _roll.SetActive(true);
                _rolling = true;
                _rollRef.SetActivity(true, 1, _player.velocity.magnitude);
                _player.transform.position = _inactive;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                _roll.SetActive(true);
                _rolling = true;
                _rollRef.SetActivity(true, -1f, _player.velocity.magnitude);
                _player.transform.position = _inactive;
            }
        }

        if (System.Math.Abs(_player.velocity.y) < .5f && !_isJumping)
            _dashing = false;

            if (Input.GetKey(KeyCode.F))
                Time.timeScale = .1f;
            else
                Time.timeScale = 1;

            if (!_dashing)
                _player.velocity = new Vector2(0, _player.velocity.y) + _direction;

            _direction.Normalize();
        }
        if (_player.velocity.y > .1f)
            _drag.friction = 0;
        else
            _drag.friction = .01f;
}
    private void FixedUpdate()
    {
        _floorHit = Physics2D.Raycast(_rayOrigin.position, -Vector2.up, .03f, LayerMask.GetMask("Floor"));
        if(_floorHit)
            _isJumping = false;
        _wallHitLeft = Physics2D.Raycast(_rayLeft.position, Vector2.left, 2f, LayerMask.GetMask("Floor"));
        if (_wallHitLeft)
            Cam.CloseToWall = true;
        else Cam.CloseToWall = false;
        _wallHitRight = Physics2D.Raycast(_rayRight.position, Vector2.right, 2f, LayerMask.GetMask("Floor"));
        if (_wallHitRight)
            Debug.Log("Hit");
        else Cam.CloseToWall = false;
    }
}
