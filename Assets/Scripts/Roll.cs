using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    //objects
    [SerializeField]
    private GameObject _roll;
    [SerializeField]
    private Rigidbody2D _rollRGBD;

    [SerializeField] private Player _playerObject = null;

    //movement
    private Vector2 _direction;
    public Transform _location;
    private RaycastHit2D _ceiling;

    //numbers
    private float _rolltime = 1f;
    private float _fallMultiplier = 2.5f;
    private float _jumpMultiplier = 2;
    private float _rollSpeed;

    //bools
    public bool _active;
    private bool _forward;
    private bool _pathClear = true;

    public bool PathClear => _pathClear;

   private void Awake() => gameObject.SetActive(false);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "AirObject")
        {
            AirObject _box = collision.gameObject.GetComponent<AirObject>();
            _box.SwapToFall();
            _rollSpeed = 6;
        }
    }

    public void SetActivity(bool _act, float _speedRef, float absSpeed)
    {
        _active = _act;
        _roll.transform.position = _location.transform.position;
        if (_speedRef >= 0)
            _forward = true;
        else
            _forward = false;
        if (absSpeed > 8 && absSpeed < 12)
            _rollSpeed = absSpeed;
        else if (absSpeed < 8)
            _rollSpeed = 8;
        else if (absSpeed > 12)
            _rollSpeed = 12;
    }

    // Update is called once per frame
    void Update()
    {
        //roll left and right
        if(_forward)
            _direction = new Vector2(_rollSpeed, 0);
        else
            _direction = new Vector2(-_rollSpeed, 0);

        //prevent infinite downward speed
        if (_rollRGBD.velocity.y < -20f)
            _rollRGBD.velocity -= Vector2.up * Physics2D.gravity.y;

        if (!_active)
        _roll.transform.position = _location.transform.position;

        _ceiling = Physics2D.Raycast((Vector2) transform.position, Vector2.up, 2f);
        _pathClear = (_ceiling ? false : true);
    }

    private void FixedUpdate()
    {
        //rotation effect
        if(_rollRGBD.velocity.x <= 0f)
            _rollRGBD.rotation += 10;
        if (_rollRGBD.velocity.x > 0f)
            _rollRGBD.rotation -= 10;

        _rollRGBD.velocity = new Vector2(0, _rollRGBD.velocity.y) + _direction;
        _direction.Normalize();
        
        
        if (Math.Abs(_rollRGBD.velocity.x) < .01f)
        {
            _playerObject.Jump();
        }
    }
}
