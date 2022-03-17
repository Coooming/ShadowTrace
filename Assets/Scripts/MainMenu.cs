using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Debug.Log("START");
        LevelManager.ToLevel(0);
    }
    
    public void ExitGame()
    {
        // Debug.Log("EXIT");
        Application.Quit();
    }
}
