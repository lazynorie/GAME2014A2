///By Jing Yuan Cheng 101257237
/// CoinController Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Header("Movement")]
    [Range(0.1f, 2.0f)] public float rotationSpeed;

    [Header("Audio")] public AudioSource pickupSound;

    private GameObject scoreManager;
    private ScoreManager scoreM;
    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        
        scoreManager = GameObject.Find("ScoreManager");
        scoreM = scoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SpinCoin();
    }

    private void SpinCoin()
    {
        transform.Rotate(Vector3.up, rotationSpeed);
    }


    private IEnumerator PlayCoinSound()
    {
        pickupSound.Play();
        scoreM.score += 200;
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayCoinSound());
        }
    }
}
