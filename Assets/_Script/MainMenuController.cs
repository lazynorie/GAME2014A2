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
