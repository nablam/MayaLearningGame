using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    public int SpeedInt=4; //Do not pass 20 or 0.2f is the MAX to never pass
    float speed ;
    public GameObject TileTest;
    public GameObject TileGrass_Dirt;
    public GameObject TileWater_Sea;

    public GameObject TileGrass_Flat;
    public GameObject TileGrass_Hill_L;
    public GameObject TileGrass_Hill_R;
    public GameObject TileGrass_Corner_L;
    public GameObject TileGrass_Corner_R;

    public GameObject TileSnow_Flat;
    public GameObject TileSnow_Hill_L;
    public GameObject TileSnow_Hill_R;
    public GameObject TileSnow_Corner_L;
    public GameObject TileSnow_Corner_R;

    public GameObject TileFall_Flat;
    public GameObject TileFall_Hill_L;
    public GameObject TileFall_Hill_R;
    public GameObject TileFall_Corner_L;
    public GameObject TileFall_Corner_R;




    float PlantedParasol = 0f;
    float DeltaPos = 0f; //it will be reseto 0 when transform has moved on the x axix in the amount of a single tile width 
    float TileSize;
    bool PopaTile=false;
    TextMesh _textMesh;
    bool isScrollingLeft=true;
    void Awake () {
        speed = ((float)SpeedInt / 100);

        Debug.Log(speed);
        TileSize = TileTest.GetComponent<SpriteRenderer>().size.x;
        PlantedParasol = Mathf.Abs(this.transform.position.x);


        Debug.Log("pop");
        PopTestTileDetachedText();
        PopaTile = true;
        PlantedParasol = Mathf.Abs(this.transform.position.x);

    }

    int tilesMade = 0;
    // Update is called once per frame
    void Update () {
        DeltaPos = Mathf.Abs(this.transform.position.x) - PlantedParasol;
        if (PopaTile)
        {
            PopaTile = false;
        }
        if (DeltaPos >= TileSize) {
            if (!PopaTile) {
                Debug.Log("pop");
                PopTestTileDetachedText();
                PopaTile = true;
                PlantedParasol = Mathf.Abs(this.transform.position.x);
            }
        }
        transform.Translate(Vector2.left * speed);
    }

    void PopTestTileDetachedText() {
        GameObject TempNewTileJustfortesting = Instantiate(TileTest, this.transform, false);
        TempNewTileJustfortesting.transform.localPosition = new Vector2((tilesMade * TileSize), 0);
        TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text= DeltaPos.ToString();
        tilesMade++;
    }

    void ScrollLeft() {

    }
    void ScrollRight() { }
}
