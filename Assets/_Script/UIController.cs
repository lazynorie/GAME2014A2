///By Jing Yuan Cheng 101257237
/// UIController Script
/// 
/// Version 21.0
/// Last edited on Dec 12 2021
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    [Header("On Screen Controls")] public GameObject onScreenControls;

    [Header("Button Control Events")]
    public static bool jumpButtonDown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CheckPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckPlatform()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.WindowsEditor:
                onScreenControls.SetActive(true);
                break;
            default:
                onScreenControls.SetActive(false);
                break;
        }
    }

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

    public void onJumpButton_Down()
    {
        jumpButtonDown = true;
    }
    
    public void onJumpButton_Up()
    {
        jumpButtonDown = false;
    }
}
