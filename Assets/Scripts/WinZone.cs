using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    [SerializeField] private string sceneName = "Title";

    // Update is called once per frame
    void SceneSwitch()
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter()
    {
        SceneSwitch();
    }
}
