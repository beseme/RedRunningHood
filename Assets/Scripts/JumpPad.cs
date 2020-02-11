using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _force = 0;
    [SerializeField] private Vector2 _angle = Vector2.zero;
    [SerializeField] private bool _transporter = false;
    [SerializeField] private float _offTime = 0;
 
    private Rigidbody2D _rig = null;

    private PlayerController _player = null;

    void Start()
    {
        _angle = Vector2.ClampMagnitude(_angle, 1);
        _force *= 80;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _rig = collision.gameObject.GetComponent<Rigidbody2D>();
            if (_transporter)
            {
                _player = collision.gameObject.GetComponent<PlayerController>();
                _player.enabled = false;
                StartCoroutine(OfftimeRoutine());
            }
            _rig.velocity = Vector2.zero;
            _rig.AddForce(_angle * _force);
        }
    }

    private IEnumerator OfftimeRoutine()
    {
        yield return new WaitForSeconds(_offTime);
        _player.enabled = true;
    }
}
