using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenTester : MonoBehaviour {

    TileGenerator tg;
    void Start () {
        tg = GetComponent<TileGenerator>();


        for (int x = 0; x < 7; x++) {

          GameObject go=  tg.ConstructColumn(x);
            go.transform.position = new Vector3(x, 0, 0);
           
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
