using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePaddle : Paddle
{
    // Config Params
    [SerializeField] float minY;
    [SerializeField] float maxY;
    int screenHeight = 12;


    public override void MovePaddle()
    {
        float posY = Input.mousePosition.y / Screen.height * screenHeight;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.y = Mathf.Clamp(posY, minY, maxY);
        transform.position = paddlePos;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MovePaddle();
    }
}
