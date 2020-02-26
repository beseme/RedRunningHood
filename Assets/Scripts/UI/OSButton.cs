using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OSButton : MonoBehaviour
{
    [SerializeField] private LevelUI _ui = null;

    public void StartPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        _ui.Menu();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
