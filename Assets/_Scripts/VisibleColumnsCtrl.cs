using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleColumnsCtrl : MonoBehaviour
{

    public TileGenerator tileGen;
    int totalVisibleTiles = 11;
    int SeaTileMax = 4;
    int TotalTileSize = 30;
    GameObject[] ActiveTiles;
    public GameObject[] GetVisibleColumns() { return this.ActiveTiles; }
    List<int> ColumnNumType;
    float Xoffset;
    private void Awake()
    {
        GenerateMap();
        ColumnNumType = new List<int>();
        ColumnNumType.Add(1);
        ColumnNumType.Add(1);
        ColumnNumType.Add(1);
        ColumnNumType.Add(1);
        ColumnNumType.Add(1);
       // ColumnNumType.Add(1);

        foreach (int x in MapLogicalStates)
        {
            ColumnNumType.Add(x);

        }
        ActiveTiles = new GameObject[totalVisibleTiles];
    }

    public float cashedFirstTilePosX;
    public float cashedLastTilePosX;
    GameObject LeftMostTileRef;
    GameObject RightMostTileRef;

    int RightIndex;
    int LeftIndex;

    void BuildBAseVisible()
    {
        MyEnums.Season curseason = MyEnums.Season.Winter;
        for (int c = 0; c < totalVisibleTiles; c++)
        {
            //if (c < totalVisibleTiles / 3) { curseason = MyEnums.Season.Spring; }
            //else
            //    if (c >= totalVisibleTiles / 3  && c < (totalVisibleTiles*2)/3) { curseason = MyEnums.Season.Winter; }
            //    else
            //     if (c > (totalVisibleTiles * 2) / 3) { curseason = MyEnums.Season.Fall; }
                  
            GameObject Column;
            if (c <= SeaTileMax )
                Column = tileGen.BuildSeaTile(ColumnNumType[c], "");
            else
                Column = tileGen.BuildTestColumn(ColumnNumType[c], "", curseason);
            Column.transform.position += new Vector3((RightIndex * Xoffset) - 12.8f, -5.2f, 0);
            ActiveTiles[c] = Column;
            RightIndex++;
        }
        LeftMostTileRef = ActiveTiles[0];
        RightMostTileRef = ActiveTiles[totalVisibleTiles - 1];
        cashedFirstTilePosX = ActiveTiles[0].transform.position.x;
        cashedLastTilePosX = ActiveTiles[totalVisibleTiles - 1].transform.position.x;
    }
    void Start()
    {
        Xoffset = tileGen.GetTileSize();
        BuildBAseVisible();
    }



    void Add_Right___Kill_LEft()
    {
        if (RightIndex == ColumnNumType.Count) return; //SendSignal stop moving
        if (RightMostTileRef.transform.position.x < (cashedLastTilePosX - Xoffset))
        {
            //sift active array whille keeping ref to LEFTMOSET
            for (int l = 0; l < ActiveTiles.Length - 1; l++)
            {
                ActiveTiles[l] = ActiveTiles[l + 1]; //now we have a duplicat at the end and no ref to the firstguy except for FIRSTTILE ref
            }
            Destroy(LeftMostTileRef);
            //make new Right column 
            //GameObject Column = tileGen.BuildTestColumn(ColumnNumType[RightIndex], "Replenish R".ToString());
            GameObject Column;

            if (RightIndex >= (TotalTileSize )) //no worries , seablocks were added to the list 
            {
                Column = tileGen.BuildSeaTile(ColumnNumType[RightIndex], "");
            }
            else
            {
                MyEnums.Season curseason = MyEnums.Season.Spring;
                //if (RightIndex < totalVisibleTiles / 3) { curseason = MyEnums.Season.Spring; }
                //else
                //    if (RightIndex >= totalVisibleTiles / 3 && RightIndex < (totalVisibleTiles * 2) / 3) { curseason = MyEnums.Season.Winter; }
                //else
                //     if (RightIndex > (totalVisibleTiles * 2) / 3) { curseason = MyEnums.Season.Fall; }
                Column   = tileGen.BuildTestColumn(ColumnNumType[RightIndex], "",curseason);
            }
            Column.transform.position += new Vector3(cashedLastTilePosX - 0.1f, -5.2f, 0);
            LeftIndex++;
            RightIndex++;
            ActiveTiles[ActiveTiles.Length - 1] = Column;
            RightMostTileRef = Column;
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
            GameObject Column;
            if (LeftIndex <= SeaTileMax )
            {
                Column = tileGen.BuildSeaTile(ColumnNumType[LeftIndex], "");
            }
            else
            {

                MyEnums.Season curseason = MyEnums.Season.Spring;
            
                Column = tileGen.BuildTestColumn(ColumnNumType[LeftIndex], "",curseason);
            }
            Column.transform.position += new Vector3(cashedFirstTilePosX + 0.1f, -5.2f, 0);

            ActiveTiles[0] = Column;
            RightMostTileRef = ActiveTiles[ActiveTiles.Length - 1];
            LeftMostTileRef = ActiveTiles[0];
        }
    }

    public bool RIGHT_EdgeReached() {
        if (RightIndex > TotalTileSize + SeaTileMax-1) return true;
        return false;
    }

    public bool LEFT_EdgeReached()
    {
        if (LeftIndex <= 0) return true;
        return false;
    }
    void Update()
    {

        Add_Right___Kill_LEft();
        Add_Left___Kill_Right();

    }

    int[] MapLogicalStates;
    void GenerateMap()
    {
        MapLogicalStates = new int[TotalTileSize];
        MapLogicalStates[0] = 0;// MyEnums.HillType.Flat;
        MapLogicalStates[1] = 0;// MyEnums.HillType.Flat;
        MapLogicalStates[2] = 0;// MyEnums.HillType.Flat;
        MapLogicalStates[3] = 0;// MyEnums.HillType.Flat;
        MapLogicalStates[4] = 0;// MyEnums.HillType.Flat;
        MapLogicalStates[5] = 0;

        for (int x = 1; x < TotalTileSize; x++)
        {
            MapLogicalStates[x] = StateChecker(MapLogicalStates[x - 1]);



        }

    }

    int StateChecker(int arglast) {
        if (arglast == 0) {
            int r2 = Random.Range(0, 2); // to 0 again || 1
            return r2;
        }
        if (arglast == 1)
        {
            return 2;//must go to a flat 
        }
        if (arglast == 2)
        {
            int r3= Random.Range(0, 3);
            int finalchoice=6; //  adds more chances of going down . reducing hills
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
            return  Random.Range(4, 6); // to 4 again || 5
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

         

    
 
 

 