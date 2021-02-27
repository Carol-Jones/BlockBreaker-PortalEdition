using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePaddle : Paddle
{
    // Config Params
    [SerializeField] float minY;
    [SerializeField] float maxY;
    int screenHeight = 12;

    GameController gameControllerRef;
    Ball ballRef;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameControllerRef = FindObjectOfType<GameController>();
        ballRef = FindObjectOfType<Ball>();
    }

    public override void MovePaddle()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(GetYPos(), minY, maxY);
        transform.position = paddlePos;
    }

    private float GetYPos()
    {
        if(gameControllerRef.IsAutoPlayEnabled())
        {
            return ballRef.transform.position.y;
        }
        else
        {
            return Input.mousePosition.y / Screen.height * screenHeight;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MovePaddle();
    }
}
