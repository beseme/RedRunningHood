using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Leveltimer : GlobalTimer
{
    [SerializeField] private int _levelIndex = 0;
    public int LevelIndex => _levelIndex;
    
    private bool _isRunning = false;
    public bool IsRunning
    {
        get => _isRunning;
        set => _isRunning = value;
    }

    void Awake()
    {
        gameObject.SetActive(false);
        _isRunning = false;
    }

  void Update()
    {
        if(_isRunning)
            TimeUpdate();
    }
}
