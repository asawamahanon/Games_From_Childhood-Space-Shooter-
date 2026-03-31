using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FristSecne");
    }
    public void ReturnHome() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");

    }
    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
