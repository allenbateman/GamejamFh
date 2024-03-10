using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{

    [SerializeField]
    private Button playBtn;
    [SerializeField]
    private Button exitBtn;

    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
