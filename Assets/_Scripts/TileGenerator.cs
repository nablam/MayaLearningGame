using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {
    int SpeedInt=3; //Do not pass 20 or 0.2f is the MAX to never pass
    float speed =0.0128f ;
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


    //float SizeTileFloat;
    //float SizeTileInt;
    //private void Start()
    //{
    //    //speed = ((float)SpeedInt / 100);
    //    SizeTileFloat = TileTest.GetComponent<SpriteRenderer>().size.x;
    //    SizeTileInt = Mathf.FloorToInt(SizeTileFloat * 100f);

    //    Debug.LogFormat("f={0} i={1}", SizeTileFloat, SizeTileInt);
    //    StartCoroutine(OtherThread());
    //}

    //void dUpdate()
    //{if (!GOOO) return;
    //    transform.Translate(Vector2.right * speed);

    //    int PosX = Mathf.FloorToInt((transform.position.x * 100f));
    //    //Debug.Log( PosX + " % " + SizeTileInt + " = " + PosX % SizeTileInt);
    //    if (PosX % Mathf.FloorToInt(SizeTileInt/2) == 0)
    //    {
    //        CurIndex = Mathf.FloorToInt(PosX / SizeTileInt);

    //        if (CurIndex < LastIndex)
    //        {
    //            Debug.Log("GOING RIGHT handle tile popint and killing accordingly");

    //            CurIndex--;
    //        }
    //        else
    //        if (CurIndex > LastIndex)
    //        {
    //            Debug.Log("GOING LEFT handle tile popint and killing accordingly");
    //            CurIndex++;
    //            PopTestTileDetachedText();

    //        }
    //        else if (CurIndex == LastIndex)
    //        {
    //            Debug.Log("I should never seev this");
    //        }
    //        else
    //        {
    //            Debug.Log("default ");
    //        }

    //        LastIndex = CurIndex;
    //    }

    //}
    //bool GOOO = false;
    //IEnumerator OtherThread() {

    //    yield return new WaitForSeconds(0.5f);
    //    GOOO = true;
    //}
    //int LastIndex = 16;
    //int CurIndex = 16;


    //void PopTestTileDetachedText()
    //{
    //    GameObject TempNewTileJustfortesting = Instantiate(TileWater_Sea);
    //    //TempNewTileJustfortesting.transform.localPosition = new Vector2((tilesMade * TileSize), 0);
    //    TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text = "";
    //    TempNewTileJustfortesting.transform.parent = this.transform;


    //}
































    float PlantedParasol = 0f;
    float DeltaPos = 0f; //it will be reseto 0 when transform has moved on the x axix in the amount of a single tile width 
    float TileSize;
    bool PopaTile = false;
    TextMesh _textMesh;
    bool isScrollingLeft = true;
    void Awake()
    {
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
    void Update()
    {
        DeltaPos = Mathf.Abs(this.transform.position.x) - PlantedParasol;
        if (PopaTile)
        {
            PopaTile = false;
        }
        if (DeltaPos >= TileSize)
        {
            if (!PopaTile)
            {
                Debug.Log("pop");
                PopTestTileDetachedText();
                PopaTile = true;
                PlantedParasol = Mathf.Abs(this.transform.position.x);
            }
        }
        transform.Translate(Vector2.left * speed);
    }

    void PopTestTileDetachedText()
    {
        //   GameObject TempNewTileJustfortesting = Instantiate(TileWater_Sea, this.transform, false);
        GameObject TempNewTileJustfortesting = Instantiate(TileWater_Sea);
     TempNewTileJustfortesting.transform.position = this.transform.TransformPoint(TempNewTileJustfortesting.transform.position)+ new Vector3((tilesMade * TileSize), 0,0);
        TempNewTileJustfortesting.transform.parent = this.transform;
        TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text = DeltaPos.ToString();
        tilesMade++;
    }

    void ScrollLeft()
    {

    }
    void ScrollRight() { }

}
