using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Range(0.1f,5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int playerScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// Contains the singleton pattern for the gamecontroller
    /// </summary>
    void Awake()
    {
        int gameControllerCount = FindObjectsOfType<GameController>().Length;
        if(gameControllerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Time.timeScale = gameSpeed; // Controls Game Speed
    }

    public void ScoreUp(int value)
    {
        playerScore += value;
        scoreText.text = "Score:" + playerScore;
    }
}
