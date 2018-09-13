using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleColumnsCtrl : MonoBehaviour {

    public TileGenerator tileGen;
    int totalVisibleTiles = 11;

    GameObject[] ActiveTiles;
    public GameObject[] GetVisibleColumns() { return this.ActiveTiles; }
    List<int> ColumnNumType;
    float Xoffset;
    private void Awake()
    {
       
        ColumnNumType = new List<int>();
        ColumnNumType.Add(1);
        ColumnNumType.Add(2);
        ColumnNumType.Add(3);
        ColumnNumType.Add(3);
        ColumnNumType.Add(1);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(3);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(3);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(3);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);


        ActiveTiles = new GameObject[totalVisibleTiles];




    }
    float LeftMostXTrigger;
    //                                 _______________________________________                                             
    //                                |                                       |
    //         - ----------------|    |Screen left edge      right screen edgr|       
    //                   ________|____|__ _______ _______ _______ _______ ____|__ ______ _______
    //                   |       |    |  |       |       |       |       |    |  |       |       |    
    //                   |       |    |  |       |       |       |       |    |  |       |       |
    //                   |_______|____|__|_______|_______|_______|_______|____|__|_______|_______|
    //      tilx center -12.8|   |    |                                       | 
    //                       |   |    |_______________________________________|
    //      edgex half tile  |---|




   public float cashedFirstTilePosX;
   public float cashedLastTilePosX;
    public GameObject LEFTMOST_TILE;
    public GameObject RIGHTMOST_TILE;

    int RightIndex;
    int LeftIndex;

    void BuildBAseVisible() {
        for (int c = 0; c < totalVisibleTiles; c++)
        {
            GameObject Column = tileGen.BuildTestColumn(ColumnNumType[c], "base /n"+c.ToString());
            Column.transform.position += new Vector3((RightIndex * Xoffset) - 12.8f, -5.2f, 0);
            ActiveTiles[c]=Column;
            RightIndex++;
        }
        LEFTMOST_TILE = ActiveTiles[0];
        RIGHTMOST_TILE = ActiveTiles[totalVisibleTiles - 1];
        cashedFirstTilePosX = ActiveTiles[0].transform.position.x;
        cashedLastTilePosX = ActiveTiles[totalVisibleTiles - 1].transform.position.x;

         
    }
    void Start () {
        Xoffset = tileGen.GetTileSize();
        BuildBAseVisible();


    }
    void ShiftVisible_Right_insertat0 (GameObject argFirst){

        GameObject[] temp = new GameObject[totalVisibleTiles];
        temp[0] = argFirst;
        for (int x = 1; x < totalVisibleTiles - 2; x++) {
            temp[x] = ActiveTiles[x + 1];
        }

        ActiveTiles = temp;
    }
    void ShiftVisible_LEFT_ADDLast(GameObject argLast)
    {
        GameObject[] temp = new GameObject[totalVisibleTiles];
        //temp[0] = argFirst;
        for (int x = 0; x < totalVisibleTiles -1 ; x++)
        {
            temp[x] = ActiveTiles[x];
        }
        temp[totalVisibleTiles - 1] = argLast;
        ActiveTiles = temp;
    }
    public void AddColumnLeft() {
        GameObject Column = tileGen.BuildTestColumn(ColumnNumType[LeftIndex], "Replenish L".ToString());
        Column.transform.position += new Vector3(cashedFirstTilePosX, -5.2f, 0);
        ShiftVisible_Right_insertat0(Column);
        LeftIndex--;
    }

    public void AddColumnRight()
    {
        GameObject Column = tileGen.BuildTestColumn(ColumnNumType[RightIndex], "Replenish R".ToString());
        Column.transform.position += new Vector3(cashedLastTilePosX, -5.2f, 0);

        ShiftVisible_LEFT_ADDLast(Column);
        RightIndex++;
    }

    bool PopaLEFTTile;
    bool PopaRIGHTTIle;
    // Update is called once per frame



    void Add_Right___Kill_LEft() {

        if (RightIndex == ColumnNumType.Count) return; //SendSignal stop moving
        if (RIGHTMOST_TILE.transform.position.x < (cashedLastTilePosX - Xoffset)) {
            //sift active array whille keeping ref to LEFTMOSET
            for (int l = 0 ; l< ActiveTiles.Length-1; l++) {
                ActiveTiles[l] = ActiveTiles[l + 1]; //now we have a duplicat at the end and no ref to the firstguy except for FIRSTTILE ref
            }
            Destroy(LEFTMOST_TILE);

            //make new Right column 
            GameObject Column = tileGen.BuildTestColumn(ColumnNumType[RightIndex], "Replenish R".ToString());
            Column.transform.position += new Vector3(cashedLastTilePosX, -5.2f, 0);            
            RightIndex++;
            ActiveTiles[ActiveTiles.Length - 1] = Column;
            RIGHTMOST_TILE = Column;
            LEFTMOST_TILE = ActiveTiles[0];
        }

    }

    void Update () {

        Add_Right___Kill_LEft();

        //if(ActiveTiles[totalVisibleTiles - 1] == null) AddColumnLeft();
        //if (ActiveTiles[totalVisibleTiles - 1].transform.position.x > cashedLastTilePosX)
        //{
        //    Destroy(ActiveTiles[totalVisibleTiles - 1]);
        //}
        //if (ActiveTiles[0] == null) AddColumnRight();
        //if (ActiveTiles[0].transform.position.x < cashedFirstTilePosX)
        //{
        //    Destroy(ActiveTiles[0]);
        //}



        //replenish LEft

        //if (PopaLEFTTile)
        //{
        //    PopaLEFTTile = false;
        //}
        //if (ActiveTiles[2].transform.position.x > cashedFirstTilePosX + Xoffset)
        //{
        //    if (!PopaLEFTTile)
        //    {
        //        Debug.Log("popleft");
        //        AddColumnLeft();
        //        PopaLEFTTile = true;
        //    }
        //}


    }
}
