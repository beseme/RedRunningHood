using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private Vector3 _targetLocation;
    [SerializeField] private bool _startStop; //true is start, false is stop
    [SerializeField] private UITimer _stop;
    [SerializeField] private GlobalTimer _count;
    [SerializeField] private Scene _timerScene;
    [SerializeField] private int load;
    [SerializeField] private int unload;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.transform.position = _targetLocation;
        if (_startStop)
        {
            //_timer.gameObject.SetActive(true);
            _stop.GetComponent<UITimer>()._timing = true;
            SceneManager.LoadScene(load, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(unload);
        }
        else
        {
            _stop.GetComponent<UITimer>()._timing = false;
            _count.GetComponent<GlobalTimer>()._timerIndex += 1;
            SceneManager.LoadScene(load, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(unload);
        }
        //SceneManager.LoadScene(load, LoadSceneMode.Additive);
        //SceneManager.UnloadScene(unload);
    }
}
