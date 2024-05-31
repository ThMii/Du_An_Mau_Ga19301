using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load Map 1
    public void LoadGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(1);
    }

    // Load về munu chính
    public void Home()
    {
        Debug.Log("Home");
        SceneManager.LoadScene(0);
    }
    //thoat game
    public void ExitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void Setting()
    {
        Debug.Log("Setting");

    }
}
