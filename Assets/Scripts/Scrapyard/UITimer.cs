using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    private Text _timerText;
    private float _time;
    public bool _timing;
    private int _minutes;

    // Start is called before the first frame update
    void Start()
    {
        _timerText = GetComponent<Text>();
        _timing = false;
        _timerText.gameObject.SetActive(false);
    }

    private void TimeUpdate()
    {
        if (_minutes == 0 && _time < 60)
            _timerText.text = _time.ToString();
        if(_minutes > 0)
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
        if (_timing)
        {
            _time += Time.deltaTime;
            TimeUpdate();
        }
    }
}
