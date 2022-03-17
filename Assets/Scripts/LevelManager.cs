using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static string[] levelSceneName = new string[3]
    {
        "World 1",
        "World 2",
        "World 3"
    };

    public int currLevel = 0;

    public static LevelManager Instance()
    {
        return GameObject.Find("GameManager").GetComponent<LevelManager>();
    }

    public void NextLevel()
    {
        if (currLevel >= 2)
        {
            currLevel = -1;
        }
        TransmittedData.lastCharacterTrack = null;
        TransmittedData.lastShadowTrack = null;
        SceneManager.LoadScene(levelSceneName[currLevel + 1]);
    }

    public static void ToLevel(int index)
    {
        TransmittedData.lastCharacterTrack = null;
        TransmittedData.lastShadowTrack = null;
        SceneManager.LoadScene(levelSceneName[index]);
    }

    public void Retry(bool shouldClearTrack)
    {
        if (shouldClearTrack)
        {
            TransmittedData.lastCharacterTrack = null;
            TransmittedData.lastShadowTrack = null;
        }
        SceneManager.LoadScene(levelSceneName[currLevel]);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            ToLevel(0);
        }
        else if (Input.GetKeyUp(KeyCode.F2))
        {
            ToLevel(1);
        }
        else if (Input.GetKeyUp(KeyCode.F3))
        {
            ToLevel(2);
        }
        else if (Input.GetKeyUp(KeyCode.F5))
        {
            Retry(true);
        }
    }
}
