using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    bool SignalGo;
    public void TurnEnginsOn() {
        StartCoroutine(GoIn5());
    }
	// Update is called once per frame
	void Update () {

        if (SignalGo)
        {
            transform.Translate(Vector2.left * 0.15f);
        }
    }

    IEnumerator GoIn5()
    {
        yield return new WaitForSeconds(5f);
        SignalGo = true;
    }

}


