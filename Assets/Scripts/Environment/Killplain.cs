using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Killplain : MonoBehaviour
{
    private bool _dimming = false;
    private float _dim = 0;
    private PostProcessVolume _colorGrade = null;
    private EnterSection _player = null;

    private void Start()
    {
        _colorGrade = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if (_dim <= 1 && _dim >= 0)
            _dim = _dimming ? _dim += Time.deltaTime * 4 : _dim -= Time.deltaTime * 2;
        else if (_dim > 1) _dim = 1;
        else _dim = 0;

        Fade();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player = collision.GetComponent<EnterSection>();
        StartCoroutine(FadeRoutine());
        if (_player)
            _dimming = true;
    }


    void Fade()
    {
        _colorGrade.weight = _dim;
    }

    private IEnumerator FadeRoutine()
    {
        yield return new WaitUntil(() => _dim >= 1);
        _player.ResetPosition();
        _dimming = false;
    }
}
