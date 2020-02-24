using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    private Text _timerText;
    private float _time;
    private int _minutes;
    public int _timerIndex;

    // Start is called before the first frame update
    void Start() => _timerText = GetComponent<Text>();

    public void TimeUpdate()
    {
        if (_minutes == 0 && _time < 60)
            _timerText.text = _time.ToString();
        if (_minutes > 0)
            _timerText.text = _minutes.ToString() + " : " + _time.ToString();
        if (_time >= 60)
        {
            _time = 0;
            _minutes += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerIndex != 4)
        {
            _time += Time.deltaTime;
            TimeUpdate();
        }
    }
}
