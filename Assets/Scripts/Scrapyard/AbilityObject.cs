using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityObject : MonoBehaviour
{
    private Rigidbody2D _ability;
    private float _lifetime = 1;
    private Collider2D _col;
    [SerializeField]
    private int _type; //Ice = 1; Fire = 2; Electric = 3
    public Vector2 _forward;

    // Start is called before the first frame update
    void Start()
    {
        _ability = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "trigger" && _type == 2)
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.GetComponent<WaterAndIce>())
        {
            var water = collision.gameObject.GetComponent<WaterAndIce>();
            water.Freeze();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(_type == 2)
        _ability.velocity = _forward * 10;
        if (_type == 1)
        {
            gameObject.transform.localScale *= 1.02f;
            _col.transform.localScale *= 1.02f;
        }

        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0)
            Destroy(gameObject);
    }
}
