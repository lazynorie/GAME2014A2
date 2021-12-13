///By Jing Yuan Cheng 101257237
/// MainMenuController Script
/// 
/// Version 1.0
/// Last edited on Dec 11 2021
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void onMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void onPlayButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void onTutorialButtonPressed()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
