using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisColsMover : MonoBehaviour {
    VisibleColumnsCtrl _vcc;
    float speed = 0.08f;
    void Awake () {
        _vcc = GetComponent<VisibleColumnsCtrl>();
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
    void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) { DoScroll_Right_toLoeft(); }
   else
           if (Input.GetKey(KeyCode.RightArrow)) { DoScroll_Left_toRight(); }
        else

            DoNothing();
    }
}
