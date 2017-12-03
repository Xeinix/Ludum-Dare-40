using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public GameObject menuMain;
    public GameObject menuHelp;


    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Help()
    {
        menuMain.SetActive(false);
        menuHelp.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        menuHelp.SetActive(false);
        menuMain.SetActive(true);
    }
}
