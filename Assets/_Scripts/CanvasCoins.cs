using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCoins : MonoBehaviour {
    public Button RightBTNRef;
    public VisColsMover GamMoverJumper;
    // Use this for initialization

    bool movingright = false;
    bool movingleft = false;
	void Start () {
        //RightBTNRef.OnPointerDown();

    }
	
	// Update is called once per frame
	void Update () {
        if (movingright) { GamMoverJumper.MoveGameRIGHT(); }
        else
              if (movingleft) { GamMoverJumper.MoveGameLEFT(); }
        else {
              GamMoverJumper.MoveGameSTOP();
        }
        }

    public void GoRight()
    {
        movingright = true;
        movingleft = false;
    }
    public void GoStop()
    {
          movingright = false;
          movingleft = false;
    }
    public void GoLeft()
    {
        movingright = false;
        movingleft = true;
    }
    public void GoJump() { GamMoverJumper.MoveJumpDino(); }
}
