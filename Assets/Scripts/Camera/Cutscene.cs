using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private GameObject _cam = null;
    [SerializeField] private GameObject _playerObject = null;
    [SerializeField] private GameObject _followObject = null;

    [SerializeField] private float _wait = 0;
    [SerializeField] private float _length = 0;

    private PostProcessVolume _letterBox = null;
    private bool _letterBoxing = false;
    private ParticleSystem _particles = null;
    private CinemachineVirtualCamera _vCam = null;
    private CameraController _shake = null;
    private PlayerController _controlls = null;
    private float _speedReset = 0;

    private void Start()
    {
        //particle effects during scene
        _particles = GetComponent<ParticleSystem>();
        _particles.Stop();
        //reference to camera
        _vCam = _cam.GetComponent<CinemachineVirtualCamera>();
        _shake = _cam.GetComponent<CameraController>();
        //reference to player
        _controlls = _playerObject.GetComponent<PlayerController>();
        //reference to follower
        _speedReset = _followObject.GetComponent<Pathfinding.AIPath>().maxSpeed;
        _followObject.GetComponent<Pathfinding.AIPath>().maxSpeed = 0;

        _letterBox = GetComponent<PostProcessVolume>();
        _letterBox.weight = 0;
    }

    private void Update()
    {
        if(_letterBox.weight <= 1 && !_letterBoxing)
            _letterBox.weight -= Time.deltaTime*10;
        else if(_letterBox.weight >= 0 && _letterBoxing)
            _letterBox.weight += Time.deltaTime*10;

    }

    public void InitiateScene()
    {
        //look at follower and zoom in
        _vCam.m_Follow = _followObject.transform;
        _vCam.m_Lens.OrthographicSize *= .5f;

        //prevent player from walking through the scene
        _controlls.enabled = false;
        _playerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _letterBoxing = true;
        
        //start the actual scene
        StartCoroutine(StartSceneRoutine());
    }

    private IEnumerator StartSceneRoutine()
    {
        yield return new WaitForSeconds(_wait);
        _particles.Play();
        _shake.StartShake(_length);
        StartCoroutine(EndSceneRoutine());
    }

    private IEnumerator EndSceneRoutine()
    {
        yield return new WaitForSeconds(_length);
        //reset everything to normal
        _letterBoxing = false;
        _vCam.m_Follow = _playerObject.transform;
        _vCam.m_Lens.OrthographicSize *= 2;
        _controlls.enabled = true;
        _followObject.GetComponent<Pathfinding.AIPath>().maxSpeed = _speedReset;
        Destroy(gameObject);
    }
}
