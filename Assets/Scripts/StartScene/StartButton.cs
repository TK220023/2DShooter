using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] Button startButton;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Sky");
    }
}
