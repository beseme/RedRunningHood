﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VertMarker : MonoBehaviour
{
    [SerializeField] private Collider _confinerCollider = null;
    [SerializeField] private CinemachineVirtualCamera[] _vCam = null; // 0 is own; 1 is neighbour 
    [SerializeField] private GameObject _neighbour = null;
    [SerializeField] private bool _pushNeeded = false;

    private Vector2[] _confinerBounds = new Vector2[4];
    private Vector2[] _cameraOffset = new Vector2[4];
    // Start is called before the first frame update
    void Start()
    {
        _confinerBounds[0] = _confinerCollider.bounds.min;
        _confinerBounds[1] = new Vector2(_confinerCollider.bounds.min.x, _confinerCollider.bounds.max.y);
        _confinerBounds[2] = new Vector2(_confinerCollider.bounds.max.x, _confinerCollider.bounds.min.y);
        _confinerBounds[3] = _confinerCollider.bounds.max;

        Vector2 camSize = new Vector2(UnityEngine.Camera.main.orthographicSize * UnityEngine.Camera.main.aspect,
            UnityEngine.Camera.main.orthographicSize);
        _cameraOffset[0] = camSize;
        _cameraOffset[1] = camSize * Vector2.down;
        _cameraOffset[2] = camSize * Vector2.left;
        _cameraOffset[3] = -camSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {

            //switch cameras 

            _vCam[0].gameObject.SetActive(true);
            _vCam[1].gameObject.SetActive(false);

            //set camera position

            FindClosest();

            //push player into section

            if (_pushNeeded)
                collision.gameObject.GetComponent<EnterSection>().PushUp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // swap markers

        _neighbour.SetActive(true);
        gameObject.SetActive(false);
    }

    void FindClosest()
    {
        int closest = 0; // index for closest bound

        // set distance to compare with
        float distance = ((Vector2)transform.position - _confinerBounds[0]).magnitude;

        // compare
        for (int i = 1; i < _confinerBounds.Length; i++)
        {
            float compare = ((Vector2)transform.position - _confinerBounds[i]).magnitude;
            if (compare < distance)
            {
                compare = distance;
                closest = i;
            }
        }

        // set camera position to closest bound while keeping camera size in mind

        if (Mathf.Abs(((Vector2)transform.position - _confinerBounds[closest]).x) < _cameraOffset[closest].x)
        {
            _vCam[0].transform.position = (Vector2)transform.position + new Vector2(_cameraOffset[closest].y, 0);
        }
        else
        {
            _vCam[0].transform.position = (Vector3)_confinerBounds[closest] +
            (Vector3)_cameraOffset[closest] +
            Vector3.back * _vCam[0].transform.position.z;
        }
    }
}