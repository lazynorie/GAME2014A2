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
