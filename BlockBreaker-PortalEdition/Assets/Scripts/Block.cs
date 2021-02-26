using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Params
    int scoreValue = 5;

    // References
    [SerializeField] AudioClip breakSound;
    [SerializeField] LevelController level;
    [SerializeField] float breakSoundVolume = 0.3f;
    GameController gameController;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        level = FindObjectOfType<LevelController>();
        level.AddUpBreakableBlocks();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        DestroyBlock();
        gameController.ScoreUp(scoreValue);
    }

    void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position, breakSoundVolume);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
