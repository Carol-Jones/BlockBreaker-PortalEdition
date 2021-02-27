using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] GameObject paddleRef;
    float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    bool isBallLocked = true;
    [Range(0.01f,3f)] [SerializeField] float yRandomFactor = 0.2f;
    [Range(0.01f,3f)] [SerializeField] float xRandomFactor = 0.2f;

    // State
    Vector2 paddleToBallVec;
    AudioSource audioSource;
    
    // Caches References
    [SerializeField] AudioClip[] ballClips;
    [SerializeField] AudioClip wallBounce;
    Rigidbody2D rb2d;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        paddleToBallVec = transform.position - paddleRef.transform.position;
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
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
            xVelocity = Random.Range(-2f,2f);
            isBallLocked = false;
            rb2d.velocity = new Vector2(xVelocity, yVelocity);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, xRandomFactor), Random.Range(0, yRandomFactor));
        if(!isBallLocked)
        {
            AudioClip ballSound = ballClips[Random.Range(0,ballClips.Length)];
            audioSource.PlayOneShot(ballSound);
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(wallBounce);
        }
        rb2d.velocity += velocityTweak;
    }
}
