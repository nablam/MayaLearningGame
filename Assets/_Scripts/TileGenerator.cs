using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    public GameObject TileTest;
    public GameObject TileDirt_Dirt;
    public GameObject TileWater_Sea;

    public GameObject TileGrass_Flat;
    public GameObject TileGrass_Hill_L;
    public GameObject TileGrass_Hill_R;
    public GameObject TileGrass_Corner_L;
    public GameObject TileGrass_Corner_R;

    List<GameObject> GrassTiles;

    public GameObject TileSnow_Flat;
    public GameObject TileSnow_Hill_L;
    public GameObject TileSnow_Hill_R;
    public GameObject TileSnow_Corner_L;
    public GameObject TileSnow_Corner_R;

    List<GameObject> FallTiles;

    public GameObject TileFall_Flat;
    public GameObject TileFall_Hill_L;
    public GameObject TileFall_Hill_R;
    public GameObject TileFall_Corner_L;
    public GameObject TileFall_Corner_R;

    List<GameObject> SnowTiles;

    List<GameObject> CurrSeasonTile;


    float TileSize;
    public float GetTileSize() { return this.TileSize; }
    private void Awake()
    {
        TileSize = TileTest.GetComponent<SpriteRenderer>().size.x;
        GrassTiles = new List<GameObject>();
        GrassTiles.Add(TileGrass_Flat);
        GrassTiles.Add(TileGrass_Hill_L);
        GrassTiles.Add(TileGrass_Hill_R);
        GrassTiles.Add(TileGrass_Corner_L);
        GrassTiles.Add(TileGrass_Corner_R);

        FallTiles = new List<GameObject>();
        FallTiles.Add(TileFall_Flat);
        FallTiles.Add(TileFall_Hill_L);
        FallTiles.Add(TileFall_Hill_R);
        FallTiles.Add(TileFall_Corner_L);
        FallTiles.Add(TileFall_Corner_R);

        SnowTiles = new List<GameObject>();
        SnowTiles.Add(TileSnow_Flat);
        SnowTiles.Add(TileSnow_Hill_L);
        SnowTiles.Add(TileSnow_Hill_R);
        SnowTiles.Add(TileSnow_Corner_L);
        SnowTiles.Add(TileSnow_Corner_R);


        CurrSeasonTile = FallTiles;
    }


    private void Start()
    {
     //   BuildTestColumn(3,"column12");
    }

    public GameObject BuildTestColumn(int argHeight, string argName) {
        //GameObject Column = new GameObject();
        //for (int h = 0; h < argHeight; h++) {
        //    GameObject Tile = Instantiate(TileTest);
        //    Tile.transform.position += new Vector3(0, h*TileSize, 0);
        //    Tile.transform.parent = Column.transform;
        //    Tile.transform.GetChild(0).GetComponent<TextMesh>().text = argName+"_"+ h.ToString();
        //}
        //Column.name = argName;

        return ConstructColumn(argHeight);
        
    }

    public GameObject BuildColumn(int argStaeType, string argName)
    {
        GameObject Column = new GameObject();



        for (int h = 0; h < argStaeType; h++)
        {
            GameObject Tile = Instantiate(TileTest);
            Tile.transform.position += new Vector3(0, h * TileSize, 0);
            Tile.transform.parent = Column.transform;
            Tile.transform.GetChild(0).GetComponent<TextMesh>().text = "";
        }
        Column.name = argName;
        return Column;
    }


    public GameObject ConstructColumn(int argx) {
        GameObject Column = new GameObject();
        GameObject Dirt=null;
        GameObject Flat = null;
        GameObject CornerUPhill=null;
        GameObject CornerDownhill = null;

        GameObject Hillup = null;
        GameObject HIllDown = null;
        switch (argx) {

            case 0:
                Flat = Instantiate(CurrSeasonTile[0]);
                Flat.transform.position += new Vector3(0, 0 * TileSize, 0);
                Flat.transform.parent = Column.transform;
                Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";
                break;
          case 1:
                CornerUPhill = Instantiate(CurrSeasonTile[3]);
                CornerUPhill.transform.position += new Vector3(0, 0 * TileSize, 0);
                CornerUPhill.transform.parent = Column.transform;
                CornerUPhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                Hillup = Instantiate(CurrSeasonTile[1]);
                Hillup.transform.position += new Vector3(0, 1 * TileSize, 0);
                Hillup.transform.parent = Column.transform;
                Hillup.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                break;
            case 2:
                Dirt = Instantiate(TileDirt_Dirt);
                Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
                Dirt.transform.parent = Column.transform;
                Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                Flat = Instantiate(CurrSeasonTile[0]);
                Flat.transform.position += new Vector3(0, 1 * TileSize, 0);
                Flat.transform.parent = Column.transform;
                Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";
                break;
            case 3:

                Dirt = Instantiate(TileDirt_Dirt);
                Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
                Dirt.transform.parent = Column.transform;
                Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                CornerUPhill = Instantiate(CurrSeasonTile[3]);
                CornerUPhill.transform.position += new Vector3(0, 1 * TileSize, 0);
                CornerUPhill.transform.parent = Column.transform;
                CornerUPhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                Hillup = Instantiate(CurrSeasonTile[1]);
                Hillup.transform.position += new Vector3(0, 2 * TileSize, 0);
                Hillup.transform.parent = Column.transform;
                Hillup.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                break;
            case 4:
                Dirt = Instantiate(TileDirt_Dirt);
                Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
                Dirt.transform.parent = Column.transform;
                Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                Dirt = Instantiate(TileDirt_Dirt);
                Dirt.transform.position += new Vector3(0, 1 * TileSize, 0);
                Dirt.transform.parent = Column.transform;
                Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                Flat = Instantiate(CurrSeasonTile[0]);
                Flat.transform.position += new Vector3(0, 2 * TileSize, 0);
                Flat.transform.parent = Column.transform;
                Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";
                break;
            case 5:
                Dirt = Instantiate(TileDirt_Dirt);
                Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
                Dirt.transform.parent = Column.transform;
                Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                CornerDownhill = Instantiate(CurrSeasonTile[4]);
                CornerDownhill.transform.position += new Vector3(0, 1 * TileSize, 0);
                CornerDownhill.transform.parent = Column.transform;
                CornerDownhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                HIllDown = Instantiate(CurrSeasonTile[2]);
                HIllDown.transform.position += new Vector3(0, 2 * TileSize, 0);
                HIllDown.transform.parent = Column.transform;
                HIllDown.transform.GetChild(0).GetComponent<TextMesh>().text = "";
                break;
            case 6:



                CornerDownhill = Instantiate(CurrSeasonTile[4]);
                CornerDownhill.transform.position += new Vector3(0, 0 * TileSize, 0);
                CornerDownhill.transform.parent = Column.transform;
                CornerDownhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                HIllDown = Instantiate(CurrSeasonTile[2]);
                HIllDown.transform.position += new Vector3(0, 1 * TileSize, 0);
                HIllDown.transform.parent = Column.transform;
                HIllDown.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                break;
        }




        Column.name = "state_"+argx;

        return Column;

    }








    //public GameObject ConstructColumnFORDESCENDINGtosee(int argx)
    //{
    //    GameObject Column = new GameObject();
    //    GameObject Dirt = null;
    //    GameObject Flat = null;
    //    GameObject CornerUPhill = null;
    //    GameObject CornerDownhill = null;

    //    GameObject Hillup = null;
    //    GameObject HIllDown = null;
    //    switch (argx)
    //    {

    //        case 0: //if last state was 0 --> water state7
    //            Flat = Instantiate(TileWater_Sea);
    //            Flat.transform.position += new Vector3(0, 0 * TileSize, 0);
    //            Flat.transform.parent = Column.transform;
    //            Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";
    //            break;
    //        case 1:
    //            Dirt = Instantiate(TileDirt_Dirt);
    //            Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
    //            Dirt.transform.parent = Column.transform;
    //            Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            Flat = Instantiate(CurrSeasonTile[0]);
    //            Flat.transform.position += new Vector3(0, 1 * TileSize, 0);
    //            Flat.transform.parent = Column.transform;
    //            Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";

               

    //            break;
    //        case 2:

    //            break;
    //        case 3:

    //            Dirt = Instantiate(TileDirt_Dirt);
    //            Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
    //            Dirt.transform.parent = Column.transform;
    //            Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            CornerUPhill = Instantiate(CurrSeasonTile[3]);
    //            CornerUPhill.transform.position += new Vector3(0, 1 * TileSize, 0);
    //            CornerUPhill.transform.parent = Column.transform;
    //            CornerUPhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            Hillup = Instantiate(CurrSeasonTile[1]);
    //            Hillup.transform.position += new Vector3(0, 2 * TileSize, 0);
    //            Hillup.transform.parent = Column.transform;
    //            Hillup.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            break;
    //        case 4:
    //            Dirt = Instantiate(TileDirt_Dirt);
    //            Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
    //            Dirt.transform.parent = Column.transform;
    //            Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            Dirt = Instantiate(TileDirt_Dirt);
    //            Dirt.transform.position += new Vector3(0, 1 * TileSize, 0);
    //            Dirt.transform.parent = Column.transform;
    //            Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            Flat = Instantiate(CurrSeasonTile[0]);
    //            Flat.transform.position += new Vector3(0, 2 * TileSize, 0);
    //            Flat.transform.parent = Column.transform;
    //            Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";
    //            break;
    //        case 5:
    //            Dirt = Instantiate(TileDirt_Dirt);
    //            Dirt.transform.position += new Vector3(0, 0 * TileSize, 0);
    //            Dirt.transform.parent = Column.transform;
    //            Dirt.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            CornerDownhill = Instantiate(CurrSeasonTile[4]);
    //            CornerDownhill.transform.position += new Vector3(0, 1 * TileSize, 0);
    //            CornerDownhill.transform.parent = Column.transform;
    //            CornerDownhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            HIllDown = Instantiate(CurrSeasonTile[2]);
    //            HIllDown.transform.position += new Vector3(0, 2 * TileSize, 0);
    //            HIllDown.transform.parent = Column.transform;
    //            HIllDown.transform.GetChild(0).GetComponent<TextMesh>().text = "";
    //            break;
    //        case 6:



    //            CornerDownhill = Instantiate(CurrSeasonTile[4]);
    //            CornerDownhill.transform.position += new Vector3(0, 0 * TileSize, 0);
    //            CornerDownhill.transform.parent = Column.transform;
    //            CornerDownhill.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            HIllDown = Instantiate(CurrSeasonTile[2]);
    //            HIllDown.transform.position += new Vector3(0, 1 * TileSize, 0);
    //            HIllDown.transform.parent = Column.transform;
    //            HIllDown.transform.GetChild(0).GetComponent<TextMesh>().text = "";

    //            break;
    //    }




    //    Column.name = "state_" + argx;

    //    return Column;

    //}


























    public GameObject BuildSeaTile(int argHeight, string argName)
    {
        argHeight = 1;
        GameObject Column = new GameObject();
        for (int h = 0; h < argHeight; h++)
        {
            GameObject Tile = Instantiate(TileWater_Sea);
            Tile.transform.position += new Vector3(0, h * TileSize, 0);
            Tile.transform.parent = Column.transform;
            Tile.transform.GetChild(0).GetComponent<TextMesh>().text = "";
        }
        Column.name = "Seablock";
        return Column;
    }







}


//void PopTestTileDetachedText()
//{
//    //   GameObject TempNewTileJustfortesting = Instantiate(TileWater_Sea, this.transform, false);
//    GameObject TempNewTileJustfortesting = Instantiate(TileGrass_Flat, RightSpawn, false);
//    // TempNewTileJustfortesting.transform.position = this.transform.TransformPoint(TempNewTileJustfortesting.transform.position)+ new Vector3((TilesAmount_fromMidToRight * TileSize), 0,0);
//    // TempNewTileJustfortesting.transform.position = this.transform.InverseTransformPoint(TempNewTileJustfortesting.transform.position) ;

//    TempNewTileJustfortesting.transform.parent = this.transform;
//    TempNewTileJustfortesting.transform.localPosition = transform.GetChild(transform.childCount - 1).localPosition;
//    TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text = DeltaPos.ToString();
//    TilesAmount_fromMidToRight++;
//    Destroy(this.transform.GetChild(0).gameObject);
//}


//Kinda working no modulo or division


//int ArraySize = 15;
//int[] ArraScriptedColumns = new int[3];

//float PlantedParasol = 0f;
//float DeltaPos = 0f; //it will be reseto 0 when transform has moved on the x axix in the amount of a single tile width 
//float TileSize;
//bool PopaTile = false;
//TextMesh _textMesh;
//bool isScrollingLeft = true;
//int AlreadyExistingTiles = 10;
//void Awake()
//{
//    ArraScriptedColumns = new int[ArraySize];
//    speed = ((float)SpeedInt / 100);

//    Debug.Log(speed);
//    TileSize = TileTest.GetComponent<SpriteRenderer>().size.x;
//    PlantedParasol = Mathf.Abs(this.transform.position.x);


//    Debug.Log("pop");
//    Pop_ForLeftScrole();
//    PopaTile = true;
//    PlantedParasol = Mathf.Abs(this.transform.position.x);

//}

//int TilesAmount_fromMidToRight = 6; //from center of screen , there are 6
//int TilesAmount_fromMidToLeft = 6;
//int LeftIndex = 0;
//int RightIndex = 10;
//// Update is called once per frame

// bool ScrollingLeft = true;
//void Update()
//{
//    if (Input.GetKeyDown(KeyCode.P)) {
//        Debug.Log("pressed");
//        isScrollingLeft = false;
//    }
//    if (ScrollingLeft)
//        ScrollLeft();
//    else
//        ScrollRight();
//}
//void Pop_ForLeftScrole()
//{
//    GameObject TempNewTileJustfortesting = Instantiate(TileGrass_Flat, RightSpawn, true);
//    // TempNewTileJustfortesting.transform.position = this.transform.TransformPoint(TempNewTileJustfortesting.transform.position)+ new Vector3((TilesAmount_fromMidToRight * TileSize), 0,0);
//    // TempNewTileJustfortesting.transform.position = this.transform.InverseTransformPoint(TempNewTileJustfortesting.transform.position) ;

//    TempNewTileJustfortesting.transform.parent = this.transform;
//    TempNewTileJustfortesting.transform.position = this.transform.TransformPoint(TempNewTileJustfortesting.transform.position) + new Vector3((RightIndex * TileSize), 0, 0);
//    TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text = DeltaPos.ToString();
//    RightIndex++;
//    LeftIndex++; 
//    Destroy(this.transform.GetChild(0).gameObject);
//}
//void Pop_ForRightScrole()
//{
//    GameObject TempNewTileJustfortesting = Instantiate(TileGrass_Flat, RightSpawn, true);
//    // TempNewTileJustfortesting.transform.position = this.transform.TransformPoint(TempNewTileJustfortesting.transform.position)+ new Vector3((TilesAmount_fromMidToRight * TileSize), 0,0);
//    // TempNewTileJustfortesting.transform.position = this.transform.InverseTransformPoint(TempNewTileJustfortesting.transform.position) ;

//    TempNewTileJustfortesting.transform.parent = this.transform;
//    TempNewTileJustfortesting.transform.position = this.transform.TransformPoint(TempNewTileJustfortesting.transform.position) + new Vector3((LeftIndex * TileSize), 0, 0);
//    TempNewTileJustfortesting.transform.GetChild(0).GetComponent<TextMesh>().text = DeltaPos.ToString();
//    RightIndex--;
//    LeftIndex--;
//    Destroy(this.transform.GetChild(this.transform.childCount - 1).gameObject);
//}


//void ScrollLeft()
//{
//    if (RightIndex < ArraySize)
//    {
//        transform.Translate(Vector2.left * speed);

//        DeltaPos = Mathf.Abs(this.transform.position.x) - PlantedParasol;
//        if (PopaTile)
//        {
//            PopaTile = false;
//        }
//        if (DeltaPos >= TileSize)
//        {
//            if (!PopaTile)
//            {
//                Debug.Log("pop");
//                Pop_ForLeftScrole();
//                PopaTile = true;
//                PlantedParasol = Mathf.Abs(this.transform.position.x);
//            }
//        }
//    }


//}
//void ScrollRight()
//{
//    if (LeftIndex >0)
//    {
//        transform.Translate(Vector2.right * speed);

//        DeltaPos = Mathf.Abs(this.transform.position.x) - PlantedParasol;
//        if (PopaTile)
//        {
//            PopaTile = false;
//        }
//        if (DeltaPos >= TileSize)
//        {
//            if (!PopaTile)
//            {
//                Debug.Log("pop");
//                Pop_ForRightScrole();
//                PopaTile = true;
//                PlantedParasol = Mathf.Abs(this.transform.position.x);
//            }
//        }
//    }
//}





















///not working modulo
///
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



