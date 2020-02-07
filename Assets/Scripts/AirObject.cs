using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _fallBox;
    //[SerializeField]
    private GameObject _flyBox;
    //[SerializeField]
    private SpriteRenderer _boxSprite;
    //[SerializeField]
    private Collider2D _collision;
    private bool _alive;
    private float lifetime = 4;
    // Start is called before the first frame update
    void Start()
    {
       _flyBox = GetComponent<GameObject>();
        _collision = GetComponent<Collider2D>();
       _fallBox.SetActive(false);
       _boxSprite = GetComponent<SpriteRenderer>();
       _alive = true;
       _boxSprite.enabled = true;
    }

    public void SwapToFall()
    {
        _fallBox.SetActive(true);
        _boxSprite.enabled = false;
        _collision.enabled = false;
        _alive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_alive)
        {
            lifetime -= Time.deltaTime;
            if(lifetime <= 0)
            {
                Destroy(_fallBox);
                Destroy(_flyBox);
            }
        }
    }
}
