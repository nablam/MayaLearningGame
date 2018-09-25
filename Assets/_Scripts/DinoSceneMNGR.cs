using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoSceneMNGR : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetLevel()
    {
        SceneManager.LoadScene("DinoSceneoriginal");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
