using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OSButton : MonoBehaviour
{
    public void StartPlay()
    {
        SceneManager.LoadScene(1);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }
}
