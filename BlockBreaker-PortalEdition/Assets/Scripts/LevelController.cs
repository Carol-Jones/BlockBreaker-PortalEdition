using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    // Parameterss
    [SerializeField] int numOfBlocks = 0;

    // Cached References
    SceneController sceneController;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    public void AddUpBreakableBlocks()
    {
        numOfBlocks++;
    }

    public void BlockDestroyed()
    {
        numOfBlocks--;
        if(numOfBlocks <= 0)
        {
            sceneController.NextScene();
        }
    }        
}
