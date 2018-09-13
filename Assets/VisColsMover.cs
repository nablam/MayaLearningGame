using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisColsMover : MonoBehaviour {
    VisibleColumnsCtrl _vcc;
    
    void Awake () {
        _vcc = GetComponent<VisibleColumnsCtrl>();
    }
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject go in _vcc.GetVisibleColumns()) {
            if (go == null) continue;
            go.transform.Translate(Vector2.left * 0.02f);
        }
    }
}
