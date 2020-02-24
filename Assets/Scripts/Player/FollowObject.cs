using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    //objects
    private Rigidbody2D _mvmnt;
    [SerializeField]
    private GameObject _player = null;
    [SerializeField]
    private GameObject _roll = null;
    [SerializeField]
    private Player _playerRef;

    //movement
    private Vector2 _direction;
    private Transform _follow;
    public Transform Player;
    public Transform Roll;

    private float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _mvmnt = GetComponent<Rigidbody2D>();
        _follow = Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerRef.ActorObject.Rolling)
            _follow = Player;
        else
            _follow = Roll;

        Vector2 _dir = _follow.position - gameObject.transform.position;
        _mvmnt.velocity = _dir.normalized * speed;
        Vector2 _lookAt = _follow.transform.position - transform.position;
        transform.up = _lookAt.normalized;
    }
}
