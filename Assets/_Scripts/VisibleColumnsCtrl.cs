using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleColumnsCtrl : MonoBehaviour
{

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
        ColumnNumType.Add(1);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(3);
        ColumnNumType.Add(3);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(1);
        ColumnNumType.Add(1);
        ColumnNumType.Add(2);
        ColumnNumType.Add(2);
        ColumnNumType.Add(3);
        ColumnNumType.Add(3);
        ColumnNumType.Add(2);
        ColumnNumType.Add(1);
        ColumnNumType.Add(1);
        ColumnNumType.Add(2);
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
        for (int c = 0; c < totalVisibleTiles; c++)
        {
            GameObject Column = tileGen.BuildTestColumn(ColumnNumType[c], "base /n" + c.ToString());
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
            GameObject Column = tileGen.BuildTestColumn(ColumnNumType[RightIndex], "Replenish R".ToString());
            Column.transform.position += new Vector3(cashedLastTilePosX-0.1f, -5.2f, 0);
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
            GameObject Column = tileGen.BuildTestColumn(ColumnNumType[LeftIndex], "Rep /n L".ToString());
            Column.transform.position += new Vector3(cashedFirstTilePosX + 0.1f, -5.2f, 0);

            ActiveTiles[0] = Column;
            RightMostTileRef = ActiveTiles[ActiveTiles.Length - 1];
            LeftMostTileRef = ActiveTiles[0];
        }
    }

    void Update()
    {

        Add_Right___Kill_LEft();
        Add_Left___Kill_Right();

    }
}
