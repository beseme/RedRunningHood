using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //location references
    [SerializeField] private Transform _followObject = null;
    public GameObject _player;
    public GameObject _roll;
    private Transform _follow = null;
    
    //floating values
    [SerializeField] private float _zoomDistance = 0;
    [SerializeField] private float _zoomOut = 0;
    private float _zoom = 0;
    [SerializeField] private float _lookAhead;
    [SerializeField] private float _visionReset = 0;
    [SerializeField] private float _smoothen = .1f;
    private float _velZ;

    //other references
    [SerializeField] private GameObject _obj;
    //[SerializeField] private PlayerMovement _rollCheck;
    //[SerializeField] private InputManager _newRollCheck;
    [SerializeField] private Player _doubleNewRollCheck = null;
    [SerializeField] private KeyboardInput _tripleNewRollCheck = null;

    private bool _isRolling;
    
    //vectors
    private Vector3 _offset = Vector3.zero;
    private Vector3 _playerVel;
    private Vector2 _vel;
    
    public bool CloseToWall = false;
    // Start is called before the first frame update
    void Start() => transform.position = _player.transform.position;


    private void Update()
    {
        var distance = (_followObject.position - _follow.position).magnitude;
        if (distance < _zoomDistance)
            _zoom = _zoomOut;
        else
            _zoom = 10;

        if (_player.GetComponent<Player>().enabled)
            _isRolling = _doubleNewRollCheck.ActorObject.Rolling;
        else
            _isRolling = _tripleNewRollCheck.Player.Rolling;
    }

    void LateUpdate()
    {
        if (!_isRolling)
        {
            _follow = _player.transform;
            if (CloseToWall)
                _lookAhead = 0;
            else _lookAhead = _visionReset;
            _playerVel = new Vector3(_player.GetComponent<Rigidbody2D>().velocity.x,0,0);
        }
        else
        {
            _follow = _roll.transform;
            if (CloseToWall)
                _lookAhead = 0;
            else _lookAhead = _visionReset;
            _playerVel = new Vector3(_roll.GetComponent<Rigidbody2D>().velocity.x,0,0);
        }

        var smoothPosition = Vector2.SmoothDamp(transform.position, _follow.position + _playerVel * _lookAhead + Vector3.up * 2, ref _vel, _smoothen);
        var smoothZoom = Mathf.SmoothDamp(transform.position.z, -_zoom, ref _velZ, _smoothen);
        //Vector3 targetPosition = _follow.transform.position + new Vector3(0, 1.5f, -10) + _offset;
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, _smoothen);
        transform.position = (Vector3) smoothPosition + Vector3.forward * smoothZoom;
    }
}
