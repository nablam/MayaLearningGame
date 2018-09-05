using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public GameObject UiCanvas;
    public GameObject BTN_totheMoon;
    public GameObject BTN_Rest;

    public SpaceShipCTRL MySpaceShip;



    //public delegate void GgameContinuedEvent(bool argonoff);
    //public static GgameContinuedEvent OnGameContinue;
    //public void SignalGameContinue(bool argonoff)
    //{
    //    if (OnGameContinue != null) OnGameContinue(argonoff);
    //}


    // Use this for initialization
    void Start () {
        UiCanvas.SetActive(false);
    }
	
    public void ResetLevel() {
        SceneManager.LoadScene("SpaceScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToTheMoon() {
        MySpaceShip.Ignition();
    }

    public void ShowCanvas() {
        UiCanvas.SetActive(true);
    }
    public void ShowGoToMonne()
    {
        BTN_totheMoon.SetActive(true);
        BTN_Rest.SetActive(false);
    }


    public void ShowReset()
    {
        BTN_totheMoon.SetActive(false);
        BTN_Rest.SetActive(true);
    }

}
