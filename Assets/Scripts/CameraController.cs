using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vCam = null;
    [SerializeField] private float _shakeFreq = 0;
    [SerializeField] private float _shakeAmp = 0;

    [SerializeField] private CinemachineCameraOffset _offset = null;
    private CinemachineBasicMultiChannelPerlin _noise = null;

    private bool _shaking = false;

    private float _shakeTime = 0;

    private void Awake()
    {
        _noise = _vCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    private void LateUpdate()
    {
        if (_shaking)
        {
            //float offset = Mathf.Sin(_shakeFreq * Time.deltaTime) * _shakeAmp;
            //_offset.m_Offset = new Vector3(offset, offset, 0);
            _noise.m_AmplitudeGain = _shakeAmp;
            _noise.m_FrequencyGain = _shakeFreq;
        }
    }

    public void StartShake(float time)
    {
        _shakeTime = time;
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        _shaking = true;
        yield return new WaitForSeconds(_shakeTime);
        _shaking = false;
        _noise.m_AmplitudeGain = 0;
        _noise.m_FrequencyGain = 0;
        //_offset.m_Offset = Vector3.zero;
    }
}
