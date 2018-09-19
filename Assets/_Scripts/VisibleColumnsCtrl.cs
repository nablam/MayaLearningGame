using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleColumnsCtrl : MonoBehaviour
{
    public float cashedFirstTilePosX;
    public float cashedLastTilePosX;
    public TileGenerator tileGen;
    public int CoinsNeededMAx10=10;
    GameObject LeftMostTileRef;
    GameObject RightMostTileRef;
    int RightIndex;
    int LeftIndex;
    int totalVisibleTiles = 11;
    int SeaTileMax = 4;
    int StartFlatTiles = 3;
    int MapSize = 60;
    int CoinsCount = 0; //is incremented at mapgeneration
    GameObject[] ActiveTiles;
    float Xoffset;
    ColumnData[] Columns;// array for logic 
  ///  List<ColumnData> RealColumnsUsed;//list for idkwhy

    private void Awake()
    {
        GenerateMap();
        Debug.Log("making " + CoinsCount + " coins");
        ActiveTiles = new GameObject[totalVisibleTiles];
    }

    void Start()
    {
        Xoffset = tileGen.GetTileSize();
        BuildBAseVisible();
    }

    void Update()
    {

        Add_Right___Kill_LEft();
        Add_Left___Kill_Right();

    }

    public GameObject[] GetVisibleColumns() { return this.ActiveTiles; }

    public bool RIGHT_EdgeReached()
    {
        if (RightIndex >= MapSize) return true;
        return false;
    }

    public bool LEFT_EdgeReached()
    {
        if (LeftIndex <= 0) return true;
        return false;
    }

    public void SetColumnDataCoinPickup(int id ) {
        Columns[id].Mypickup = MyEnums.Pickup.None;
    }

    void BuildBAseVisible()
    {
        for (int c = 0; c < totalVisibleTiles; c++)
        {
            GameObject ColumnObj = tileGen.BuildColumnFromBluePrint(Columns[c],c);
            ColumnObj.transform.position += new Vector3((RightIndex * Xoffset) - 12.8f, -5.2f, 0);
            ActiveTiles[c] = ColumnObj;
            RightIndex++;
        }
        LeftMostTileRef = ActiveTiles[0];
        RightMostTileRef = ActiveTiles[totalVisibleTiles - 1];
        cashedFirstTilePosX = ActiveTiles[0].transform.position.x;
        cashedLastTilePosX = ActiveTiles[totalVisibleTiles - 1].transform.position.x;
    }
    
    void Add_Right___Kill_LEft()
    {
        if (RightIndex == Columns.Length) return; //SendSignal stop moving
        if (RightMostTileRef.transform.position.x < (cashedLastTilePosX - Xoffset))
        {
            for (int l = 0; l < ActiveTiles.Length - 1; l++)
            {
                ActiveTiles[l] = ActiveTiles[l + 1]; //now we have a duplicat at the end and no ref to the firstguy except for FIRSTTILE ref
            }
            Destroy(LeftMostTileRef);
            GameObject ColumnObj = tileGen.BuildColumnFromBluePrint(Columns[RightIndex], RightIndex);

            ColumnObj.transform.position += new Vector3(cashedLastTilePosX - 0.1f, -5.2f, 0);
            LeftIndex++;
            RightIndex++;
            ActiveTiles[ActiveTiles.Length - 1] = ColumnObj;
            RightMostTileRef = ColumnObj;
            LeftMostTileRef = ActiveTiles[0];
        }
    }

    void Add_Left___Kill_Right()
    {
        if (LeftIndex == 0) return; //SendSignal stop moving
        if (LeftMostTileRef.transform.position.x > (cashedFirstTilePosX + Xoffset))
        {
            //sift active array whille keeping ref to LEFTMOSET
            for (int l = ActiveTiles.Length - 1; l > 0; l--)
            {
                ActiveTiles[l] = ActiveTiles[l - 1]; //now we have a duplicat at first
            }
            Destroy(RightMostTileRef);
            LeftIndex--;
            RightIndex--;
            //make new Right column 
            GameObject ColumnObj = tileGen.BuildColumnFromBluePrint(Columns[LeftIndex], LeftIndex);

            ColumnObj.transform.position += new Vector3(cashedFirstTilePosX + 0.1f, -5.2f, 0);

            ActiveTiles[0] = ColumnObj;
            RightMostTileRef = ActiveTiles[ActiveTiles.Length - 1];
            LeftMostTileRef = ActiveTiles[0];
        }
    }

    void GenerateMap()
    {
        Columns = new ColumnData[MapSize];
        //makem all -1 basically seatiles
        for (int col = 0; col < MapSize; col++)
        {
            Columns[col] = new ColumnData(-1, MyEnums.Season.Summer);
        }
        //build the center
        for (int x = SeaTileMax ; x < MapSize - SeaTileMax; x++)
        {
            int columnState;

            if (x < SeaTileMax + StartFlatTiles)
            {
                columnState = 0;
            }
            else { columnState = StateChecker(Columns[x - 1].StateNumber1); }
            Columns[x].StateNumber1 = columnState;
            Columns[x].MySeason = MyEnums.Season.Spring;
            if (x > Mathf.FloorToInt(MapSize / 3) && x <= Mathf.FloorToInt((MapSize * 2) / 3)) {
                Columns[x].MySeason = MyEnums.Season.Fall;
            } else if (x > Mathf.FloorToInt((MapSize * 2) / 3)) {
                Columns[x].MySeason = MyEnums.Season.Winter;

            }
            Columns[x].Mypickup = MyEnums.Pickup.None;

            if (CoinsCount >= CoinsNeededMAx10) continue;


            //randome coin places after the base flat onle. 
            //can only be set to coin pickup if it is a flat like stat 0 2 4 
            if (x > SeaTileMax + StartFlatTiles)
            {
                if (columnState == 0 || columnState == 2 || columnState == 4) {
                    bool makecoin = (Random.Range(0, 2) == 0) ;
                    if (makecoin) {
                        CoinsCount++;
                        Columns[x].Mypickup = MyEnums.Pickup.CoinPickup;
                    }
                }
            }
           

        }


    }

    int StateChecker(int arglast)
    {
        if (arglast == 0)
        {
            int r2 = Random.Range(0, 2); // to 0 again || 1
            return r2;
        }
        if (arglast == 1)
        {
            return 2;//must go to a flat 
        }
        if (arglast == 2)
        {
            int r3 = Random.Range(0, 3);
            int finalchoice = 6; //  adds more chances of going down . reducing hills
            if (r3 == 0)
            { finalchoice = 6; }
            if (r3 == 1)
            { finalchoice = 3; }
            if (r3 == 2)
            { finalchoice = 2; }
            return finalchoice;  //random go to 2 again || 3 || 6 
        }

        if (arglast == 3)
        {
            return 4; //force going to 4
        }

        if (arglast == 4)
        {
            return Random.Range(4, 6); // to 4 again || 5
        }

        if (arglast == 5)  //to 2  || 6
        {
            int r2 = Random.Range(0, 2);
            int finalchoice = 6; //  adds more chances of going down . reducing hills
            if (r2 > 0) finalchoice = 6;
            else
                finalchoice = 2;
            return finalchoice; //force going to 4
        }
        if (arglast == 6)
        {
            return 0; //back to 0
        }
        return 1;
    }
}