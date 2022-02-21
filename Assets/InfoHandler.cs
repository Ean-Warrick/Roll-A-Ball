using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoHandler : MonoBehaviour
{
    static public int currentScene = 1;
    static public int score = 0;
    static public int totalScore = 0;
    
    static public void nextLevel()
    {
        var nextScene = currentScene + 1;
        InfoHandler.currentScene = nextScene;
        SceneManager.LoadScene(nextScene);
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
