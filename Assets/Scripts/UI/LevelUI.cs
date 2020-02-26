using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Transform _playerPos = null;
    [SerializeField] private Transform _followPos = null;
    [SerializeField] private GameObject _uiPanel = null; 


    private Text _text = null;

    private float _distance = 0;

    void Start()
    {
        _text = GetComponent<Text>();
        _uiPanel.SetActive(false);
    }

    void Update()
    {
        _distance = Mathf.Floor((_playerPos.position - _followPos.position).magnitude);
        _text.text = _distance.ToString();
        if (_distance < 8)
            _text.color = Color.red;
        else if (_distance >= 8 && _distance < 16)
            _text.color = Color.white;
        else
            _text.color = Color.green;
    }

    public void Menu()
    {
        _uiPanel.SetActive(_uiPanel.active ? false : true);
    }
}
