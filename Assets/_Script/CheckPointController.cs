///By Jing Yuan Cheng 101257237
/// CheckPointController Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Transform spawnpoint;

    private GameController _gameController;
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindObjectOfType<GameController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameController.SetCurrentSpawnPoint(spawnpoint);
        }
    }
}
