using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public List<GameObject> Blocks;

    GameObject CurCube;

	void Start () {
        CurCube = null;

    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space)) { MakeRandBox(); }
        CheckIfNeedSpawn();

    }


    void MakeRandBox() {
        if (CurCube != null) return;

        int randindex = Random.Range(0, 3);
        CurCube = Instantiate(Blocks[randindex], transform.position, Quaternion.identity);
        Destroy(CurCube, 20f);
    }

    void CheckIfNeedSpawn() {
        if (CurCube == null) {
            MakeRandBox();
        }
    }
}
