///By Jing Yuan Cheng 101257237
/// GameController Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;

    public Transform currentSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player.position = currentSpawnPoint.position;
    }

    public void SetCurrentSpawnPoint(Transform newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }
    
    
}
