using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    // Private Vars
    [SerializeField] int numOfBlocks = 0;

    public void AddUpBreakableBlocks()
    {
        numOfBlocks++;
    }            
}
