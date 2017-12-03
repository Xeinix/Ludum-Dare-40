using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("UIManager Started.");
	}

    #region Death UI

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Retry(int level)
    {
        SceneManager.LoadScene(level);
    }

    #endregion
}
