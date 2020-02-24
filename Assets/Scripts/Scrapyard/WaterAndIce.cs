using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAndIce : MonoBehaviour
{
    [SerializeField] private ParticleSystem _droplets = null;
    [SerializeField] private GameObject _ice;
    private SpriteRenderer _water;
    // Start is called before the first frame update
    void Start()
    {
        _ice.SetActive(false);
        _water = GetComponent<SpriteRenderer>();
        _droplets.transform.localScale = Vector3.one;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() || other.gameObject.GetComponent<Roll>())
        {
            _droplets.transform.position = other.gameObject.transform.position;
            _droplets.Play();
        }
    }

    public void Freeze()
    {
        _ice.SetActive(true);
        _droplets.gameObject.SetActive(false);
        _water.enabled = false;
    }

    private IEnumerator StopParticleRoutine()
    {
        yield return new WaitForSeconds(2f);
        _droplets.Stop();
    }
}
