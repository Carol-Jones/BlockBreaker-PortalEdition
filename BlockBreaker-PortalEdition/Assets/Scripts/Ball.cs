using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] GameObject paddleRef;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] int screenWidth = 16;
    bool isBallLocked = true;

    // State
    Vector2 paddleToBallVec;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        paddleToBallVec = transform.position - paddleRef.transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(isBallLocked)
        {
            BallToPaddleLock();
            LaunchOnMouseClick();
        }
    }

    void BallToPaddleLock()
    {
        Vector2 paddlePos = new Vector2(paddleRef.transform.position.x, paddleRef.transform.position.y);
        transform.position = paddlePos + paddleToBallVec;
    }

    void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isBallLocked = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}
