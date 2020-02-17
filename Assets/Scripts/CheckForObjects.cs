using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;

public class CheckForObjects : MonoBehaviour
{
    [SerializeField] private PlayerController _inputRef = null;
    private BoxCollider2D _coll = null;

    private void Awake()
    {
        _coll = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var elObj = other.gameObject.GetComponent<ElectricObject>();
        if (elObj)
            _inputRef.Thunderstone = elObj;
    }

    private void Update()
    {
        var cam = UnityEngine.Camera.main; 
        var size = new Vector2(Trigonometry() * cam.aspect, Trigonometry());
        _coll.size = size;
        //Debug.DrawRay(gameObject.transform.position, (Vector3)_coll.size, Color.cyan, Time.deltaTime);
    }

    private float Trigonometry()
    {
        float height = -UnityEngine.Camera.main.transform.position.z;
        return Mathf.Tan(UnityEngine.Camera.main.fieldOfView / 2 * Mathf.Deg2Rad) * height * 2;
    }
}
