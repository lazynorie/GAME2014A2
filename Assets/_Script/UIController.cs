using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
