using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config Params
    int scoreValue = 5;
    [SerializeField] float breakSoundVolume = 0.3f;
    [SerializeField] Sprite[] damageSprites;

    // References
    [SerializeField] AudioClip breakSound;
    [SerializeField] LevelController level;
    [SerializeField] GameObject BlockDestroyVFX;
    GameController gameController;
    

    //State Variables
    [SerializeField] int timesHit = 0; // ONLY SERIALIZED FOR DEBUG PURPOSES

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        CountBreakableBlocks();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    void HandleHit()
    {
        timesHit++;
        int maxHits = damageSprites.Length + 1;
        if(timesHit == maxHits)
        {
            Debug.Log("Block Destroyed");
            DestroyBlock();
        }
        else
        {
            ShowNextDamageSprite();
        }
    }

    void ShowNextDamageSprite()
    {
        int spriteIndex = timesHit - 1;
        if(damageSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = damageSprites[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Block sprite is missing from array " + gameObject.name);
        }
        
    }

    void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position, breakSoundVolume);
        TriggerVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        gameController.ScoreUp(scoreValue);
    }

    void TriggerVFX()
    {
        GameObject VFXInstance = Instantiate(BlockDestroyVFX, transform.position, transform.rotation);
        Destroy(VFXInstance, 2f);
    }

    void CountBreakableBlocks()
    {
        level = FindObjectOfType<LevelController>();
        if(tag == "Breakable")
        {
            level.AddUpBreakableBlocks();
        }
    }
}
