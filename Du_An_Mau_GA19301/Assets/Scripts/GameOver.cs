using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void LoadPlayAgain()
    {
        Debug.Log("Play Again");
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Debug.Log("Thoat game.");
        Application.Quit();
    }
}
