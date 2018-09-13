using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    float speed = 4.06f;
    public GameObject TileTest;

    public GameObject TileGrass_Flat;
    public GameObject TileGrass_FlatCornerUp;
    public GameObject TileGrass_Interior;
    public GameObject TileGrass_FlatCornerDown;
    public GameObject TileGrass_HillUp;
    public GameObject TileGrass_HillDown;




    float PlantedParasol = 0f;
    float Walker = 0f; // i follow this transform plant my parasol, the walker walks with transform. when walker reaches tile width, i catapult forward and doit again
    float DeltaPos = 0f; //it will be reseto 0 when transform has moved on the x axix in the amount of a single tile width 
    float TileSize;
    bool PopaTile=false;
    TextMesh _textMesh;
    bool isScrollingLeft=true;
    void Awake () {
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
            //PlantedParasol = Mathf.Abs(this.transform.position.x);
        }
       // PopaTile = !PopaTile;
        if (DeltaPos >= TileSize) {
            if (!PopaTile) {
                Debug.Log("pop");
                PopTestTileDetachedText();
                PopaTile = true;
                PlantedParasol = Mathf.Abs(this.transform.position.x);
            }
        }


        transform.Translate(Vector2.left * speed);

        //if (PopaTile) {
        //    PopaTile = false;
        //    PlantedParasol = Mathf.Abs(this.transform.position.x);
        //}
    }

    void PopTestTileDetachedText() {

        //  new Vector2( (isScrollingLeft==true?) Mathf.Abs(this.transform.position.x) Mathf.Abs(this.transform.position.x)*-1), this.transform.position.y,this.transform.position.z):
        GameObject TempNewTileJustfortesting = Instantiate(TileTest, this.transform, false);
        TempNewTileJustfortesting.transform.localPosition = new Vector2((tilesMade * TileSize), 0);
       // TempNewTileJustfortesting.transform.parent = this.transform;
        TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text= DeltaPos.ToString();
        tilesMade++;

    }

    void ScrollLeft() {

    }
    void ScrollRight() { }
}
