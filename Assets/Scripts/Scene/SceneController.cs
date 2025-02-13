using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string sceneName;

    public void Init(string sceneName)
    {
        this.sceneName = sceneName;
    }

    public void OnClickButton()
    {
        if(sceneName == "End")
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }


        SceneManager.LoadScene(sceneName);
    }
}
