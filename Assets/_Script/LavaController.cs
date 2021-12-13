///By Jing Yuan Cheng 101257237
/// LavaController Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{

    private GameController _gameController;
    
    public GameObject playerSpawnPoint;
    public PlayerBehavior player;
    
    private GameObject scoreManager;
    private ScoreManager scoreM;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager");
        scoreM = scoreManager.GetComponent<ScoreManager>();

        _gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = _gameController.currentSpawnPoint.position;
            
            player.healthPoint--;
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            scoreM.score += 100;
            other.gameObject.SetActive(false);
        }

    }
}
