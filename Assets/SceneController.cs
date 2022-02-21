using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void PlayGame()
    {
        var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        InfoHandler.currentScene = nextScene;
        SceneManager.LoadScene(nextScene);
    }
}
