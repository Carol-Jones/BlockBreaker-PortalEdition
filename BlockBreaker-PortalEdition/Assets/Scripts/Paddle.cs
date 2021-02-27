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
    [SerializeField] AudioSource paddleAudioSource;
    GameController gameController;
    Ball ball;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        paddleAudioSource = GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
        ball = FindObjectOfType<Ball>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        
        MovePaddle();
    }

    public AudioSource GetPaddleAudioSource()
    {
        return paddleAudioSource;
    }

    public AudioClip GetPaddleSound()
    {
        return paddleSound;
    }

    /// <summary>
    /// This function will move the paddle only along the x axis to the position of where the mouse is.
    /// It calculates the position by getting the position of the mouse in x,
    /// Then it divides the position by the width of the screen which normalizes the value
    /// Then it is multiplied by the width we actually want the screen to be so that it is normalized
    /// To the screensize.
    /// </summary>
    public virtual void MovePaddle()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    /// <summary>
    /// 
    /// </summary>
    private float GetXPos()
    {
        if(gameController.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
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
            paddleAudioSource.PlayOneShot(paddleSound);
        }
    }
}
