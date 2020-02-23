using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private GameObject _cam = null;
    [SerializeField] private GameObject _playerObject = null;
    [SerializeField] private GameObject _followObject = null;

    [SerializeField] private float _wait = 0;
    [SerializeField] private float _length = 0;

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
    }   

    public void InitiateScene()
    {
        //look at follower and zoom in
        _vCam.m_Follow = _followObject.transform;
        _vCam.m_Lens.OrthographicSize *= .5f;

        //prevent player from walking through the scene
        _controlls.enabled = false;
        _playerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

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
        _vCam.m_Follow = _playerObject.transform;
        _vCam.m_Lens.OrthographicSize *= 2;
        _controlls.enabled = true;
        _followObject.GetComponent<Pathfinding.AIPath>().maxSpeed = _speedReset;
        Destroy(gameObject);
    }
}
