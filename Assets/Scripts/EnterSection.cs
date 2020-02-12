using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSection : MonoBehaviour
{
    private int direction = 0;

    [SerializeField] private float _pushSpeed = 0;
    [SerializeField] private Rigidbody2D _rig = null;
    [SerializeField] private float _upForce = 0;

    // Update is called once per frame
    void Update()
    {
        if (direction != 0)
            gameObject.transform.position += new Vector3(_pushSpeed, 0, 0) * direction * Time.deltaTime;
    }

    public void GetPush(int id)
    {
        direction = id;
        if (id != 0)
            GetComponent<PlayerController>().enabled = false;
        else
            GetComponent<PlayerController>().enabled = true;
    }

    public void PushUp()
    {
        _rig.velocity = Vector2.zero;
        _rig.AddForce(new Vector2(0, _upForce * 80));
    }
}
