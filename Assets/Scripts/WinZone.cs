using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    [SerializeField] private string sceneName = "Title";
    [SerializeField] private GameObject _youWin = null;
    [SerializeField] private float _timeWait = 2f;

    // Update is called once per frame
    void SceneSwitch()
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter(Collider ball)
    {
        ball.gameObject.SetActive(false);
        _youWin.SetActive(true);
    }

    void Update(){
        if(_youWin.activeSelf == true){
            _timeWait -= Time.deltaTime;
            print(_timeWait);
            if(_timeWait<= 0f){
                SceneSwitch();
            }
        }
    }
}
