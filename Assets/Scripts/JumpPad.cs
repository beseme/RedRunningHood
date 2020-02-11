using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float _force = 0;
    [SerializeField] private Vector2 _angle = Vector2.zero;
 
    private Rigidbody2D _rig = null;

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
            _rig.AddForce(_angle * _force);
        }
    }
}
