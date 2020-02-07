using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //[SerializeField]
    //private GameObject _platform;
   // [SerializeField]
    private Rigidbody2D _move;
    private Vector3 _startPos;
    [SerializeField]
    private Vector3 _finishPos;
    private bool _return;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = gameObject.transform.position;
        _move = GetComponent<Rigidbody2D>();
        _return = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_return)
           _move.velocity = new Vector2(1, 0);
        if(_return)
            _move.velocity = new Vector2(-1, 0);
        if (gameObject.transform.position.x >= _finishPos.x)
            _return = true;
        if (gameObject.transform.position.x <= _startPos.x)
            _return = false;
       // Debug.Log(_platform.transform.position);
    }
}
