using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Scene currScene; 

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        currScene = SceneManager.GetActiveScene();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(currScene.buildIndex + 1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Debug.Log("Quit Requested.");
        Application.Quit();
    }
}
