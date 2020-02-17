using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ElectricObject : MonoBehaviour
{
    private PostProcessVolume _flash = null;
    private LineRenderer _lightning;
    private bool _onScreen = false;
    public bool OnScreen
    {
        get => _onScreen;
        set => _onScreen = value;
    }
    

    // ----- Unity Events -----
    private void Awake()
    {
        _lightning = GetComponent<LineRenderer>();
        _lightning.enabled = false;
        _flash = GetComponent<PostProcessVolume>();
        _flash.enabled = false;
    }

    private void OnBecameVisible() => _onScreen = true;
    private void OnBecameInvisible() => _onScreen = false;
    
    // ----- Custom Events -----

    public void DrawLine()
    {
        if (_onScreen)
        {
            Vector3[] linePoints = new Vector3[2];
            linePoints[0] = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, 10));
            linePoints[1] = gameObject.transform.position;
            _lightning.enabled = true;
            _lightning.SetPositions(linePoints);
            _flash.enabled = true;
            StartCoroutine(Lightning());
        }
    }

    private IEnumerator Lightning()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
