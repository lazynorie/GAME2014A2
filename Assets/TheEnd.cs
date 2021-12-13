///By Jing Yuan Cheng 101257237
/// TheEnd Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("WinScene");
    }
}
