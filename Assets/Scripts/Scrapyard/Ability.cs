using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Timeline;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.PlayerLoop;

public class Ability : MonoBehaviour
{
    [SerializeField]
    private GameObject _ice;
    [SerializeField]
    private GameObject _fire;
    [SerializeField]
    private GameObject _electric;
    private bool _flipped;
    private bool _lightweight;
    private Rigidbody2D _playerRef;
    [SerializeField]
    private PostProcessVolume _invertedColour;
    [SerializeField]
    private ParticleSystem _backGround;
    [SerializeField]
    private ParticleSystem _foreGround;

   // public InputManager GamePad;
    

    private void Awake()
    {
        //GamePad._pad.Gameplay.Time.performed += TimeButton => TimeStop();
        //GamePad._pad.Gameplay.Ice.performed += IceButton => Ice();
    }

    // Start is called before the first frame update
    void Start()
    {
        _flipped = false;
        _playerRef = GetComponent<Rigidbody2D>();
        _lightweight = false;
        _invertedColour.enabled = false;
    }


    void TimeStop()
    {
        _lightweight = true;
        _invertedColour.enabled = true;
        _backGround.Pause();
        _foreGround.Pause();
    }

    void Ice()
    {
        GameObject curProjectile = Instantiate(_ice, transform.position, Quaternion.identity);
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "AirObject" && !_lightweight)
        {
            AirObject _box = collision.gameObject.GetComponent<AirObject>();
            _box.SwapToFall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ShootDirection;

        if (_flipped)
            ShootDirection = new Vector2(-8, 0);
        else
            ShootDirection = new Vector2(8, 0);


        //flip direction
        if (_playerRef.velocity.x > 0)
            _flipped = false;
        else if (_playerRef.velocity.x < 0)
            _flipped = true;


        //abilities below
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject curProjectile = Instantiate(_ice, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(ShootDirection.y, ShootDirection.x) * Mathf.Rad2Deg - 90));
            curProjectile.GetComponent<AbilityObject>()._forward = new Vector2(ShootDirection.x, ShootDirection.y).normalized;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject curProjectile = Instantiate(_fire, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(ShootDirection.y, ShootDirection.x) * Mathf.Rad2Deg - 90));
            curProjectile.GetComponent<AbilityObject>()._forward = new Vector2(ShootDirection.x, ShootDirection.y).normalized;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject curProjectile = Instantiate(_electric, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(ShootDirection.y, ShootDirection.x) * Mathf.Rad2Deg - 90));
            curProjectile.GetComponent<AbilityObject>()._forward = new Vector2(ShootDirection.x, ShootDirection.y).normalized;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _lightweight = true;
            _invertedColour.enabled = true;
            _backGround.Pause();
            _foreGround.Pause();
        }
        else
        {
            _lightweight = false;
            _invertedColour.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _backGround.Play();
            _foreGround.Play();
        }
    }
}
