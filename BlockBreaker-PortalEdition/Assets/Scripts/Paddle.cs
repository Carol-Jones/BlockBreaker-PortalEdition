using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config Params
    [SerializeField] int screenWidth = 16;
    [SerializeField] float minX = 0.75f;
    [SerializeField] float maxX = 15.5f;
    [SerializeField] AudioClip paddleSound;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        
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

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            AudioSource.PlayClipAtPoint(paddleSound, Camera.main.transform.position);
        }
    }
}
