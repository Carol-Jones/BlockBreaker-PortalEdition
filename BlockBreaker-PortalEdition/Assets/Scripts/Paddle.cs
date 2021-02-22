using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config Params
    [SerializeField] int screenWidth = 16;
    [SerializeField] float minX = 0.75f;
    [SerializeField] float maxX = 15.5f;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Debug.Log(Input.mousePosition);
        
        MovePaddle();
    }

    /// <summary>
    /// This function will move the paddle only along the x axis to the position of where the mouse is.
    /// It calculates the position by getting the position of the mouse in x,
    /// Then it divides the position by the width of the screen which normalizes the value
    /// Then it is multiplied by the width we actually want the screen to be so that it is normalized
    /// To the screensize.
    /// </summary>
    void MovePaddle()
    {
        float posX = Input.mousePosition.x / Screen.width * screenWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(posX, minX, maxX);
        transform.position = paddlePos;
    }
}
