using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(InfoHandler.currentScene);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
    }
}
