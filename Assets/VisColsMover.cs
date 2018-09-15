using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisColsMover : MonoBehaviour {
    VisibleColumnsCtrl _vcc;
    VisibleBackgroundCtrl _vbc;
   public  dinosimplemove _dsm;
    float speed = 0.08f;
    void Awake () {
        _vcc = GetComponent<VisibleColumnsCtrl>();
        _vbc = GetComponent<VisibleBackgroundCtrl>();
    }


    void DoScroll_Right_toLoeft(List<GameObject> argList, float speed)
    {
        foreach (GameObject go in argList)
        {
            if (go == null) continue;
            go.transform.Translate(Vector2.left * speed);
        }
    }
    void DoScroll_Left_toRight(List<GameObject> argList, float speed)
    {
        foreach (GameObject go in argList)
        {
            if (go == null) continue;
            go.transform.Translate(Vector2.right * speed);
        }
    }



    void DoScroll_Right_toLoeft()
    {
        foreach (GameObject go in _vcc.GetVisibleColumns())
        {
            if (go == null) continue;
            go.transform.Translate(Vector2.left * speed);
        }
    }
    void DoScroll_Left_toRight()
    {
        foreach (GameObject go in _vcc.GetVisibleColumns())
        {
            if (go == null) continue;
            go.transform.Translate(Vector2.right * speed);
        }
    }

    void DoNothing()
    {
        foreach (GameObject go in _vcc.GetVisibleColumns())
        {
            if (go == null) continue;
            go.transform.Translate(Vector2.zero );
        }
    }

    void ALL_LEFTWARD() {

        if (_vcc.LEFT_EdgeReached()) return;
        //   _vbc
        DoScroll_Left_toRight();

        DoScroll_Left_toRight(_vbc.Get_BS_Skyhills(), speed / 4f);
        DoScroll_Left_toRight(_vbc.Get_BS_Hill1(), speed / 3f);
        DoScroll_Left_toRight(_vbc.Get_BS_Hill2(), speed / 2f);
    }

    void ALL_RIGHTYTHEN() {
        if (_vcc.RIGHT_EdgeReached()) return;
        DoScroll_Right_toLoeft();
        DoScroll_Right_toLoeft(_vbc.Get_BS_Skyhills(), speed / 4f);
        DoScroll_Right_toLoeft(_vbc.Get_BS_Hill1(), speed / 3f);
        DoScroll_Right_toLoeft(_vbc.Get_BS_Hill2(), speed / 2f);


    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) { ALL_LEFTWARD(); _dsm.Action_Direction(-1); _dsm.Action_MoveToFood(); }
        else
           if (Input.GetKey(KeyCode.RightArrow)) { ALL_RIGHTYTHEN(); _dsm.Action_Direction(1); _dsm.Action_MoveToFood(); }
        else
        {
            _dsm.Action_WaitForFood();
            DoNothing();
        }
    }
}
