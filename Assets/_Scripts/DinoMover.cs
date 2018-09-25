using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoMover : MonoBehaviour {
    float speed=0.038f;             //Floating point variable to store the player's movement speed.
    int moveHorizontal = 0;

    DinoCTRL _dinoCtrl;
    private void Awake()
    {
        _dinoCtrl = GetComponent<DinoCTRL>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) { moveHorizontal = -1; transform.localScale = new Vector3(1, 1, 1); }
        else
        if (Input.GetKey(KeyCode.RightArrow)) { moveHorizontal = 1; transform.localScale = new Vector3(-1, 1, 1); }
        else {
            moveHorizontal = 0;
        }
        Vector2 movement = new Vector2(moveHorizontal, 0);
        transform.Translate(movement*speed);

        _dinoCtrl.SetDinoState(Mathf.Abs(moveHorizontal));

    }

    public void MoveForward_ToLeft() {
        moveHorizontal = -1;
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void MoveForward_ToRight()
    {
        moveHorizontal = 1;
        transform.localScale = new Vector3(-1, 1, 1);
    }
    public void Stop_TranslatinginUpdate() { }

}
