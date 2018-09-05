using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {


    public void GoTo_MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoTo_SpaceScene()
    {
        SceneManager.LoadScene("SpaceScene");
    }
    public void GoTo_TrainScene()
    {
        SceneManager.LoadScene("TrainScene");
    }
}
