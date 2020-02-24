using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _player;
    private bool _flipped;
    [SerializeField]
    private Animator _ani;

    [SerializeField] private Actor _playerActor = null;

    // Start is called before the first frame update
    void Start()
    {
        _flipped = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (_player.velocity.x > 1 && _flipped)
        {
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;           
             _flipped = false;
        }
        if(_player.velocity.x < -1 && !_flipped)
        {
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            _flipped = true;
        }
        //_ani.SetFloat("HorizontalSpeed", Mathf.Abs(_player.velocity.x)/ _playerActor.Speed);
        _ani.SetFloat("HorizontalSpeed", Mathf.Abs(_player.velocity.x));
        _ani.SetFloat("VerticalSpeed", _player.velocity.y);
       
        Debug.Log(_player.velocity.y);
    }
}
