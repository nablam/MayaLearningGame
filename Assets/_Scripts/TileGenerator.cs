using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public GameObject TileTest; //Must keep as the tile size setter for now
    public GameObject TileDirt_Dirt;
    public GameObject TileWater_Sea;
    public GameObject CoinObj;

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

  

    public GameObject BuildColumnFromBluePrint(ColumnData argBluePrint, int ColumnIndex_forCoinToCall)
    {
        return ConstructColumn(argBluePrint.StateNumber1, argBluePrint.MySeason, argBluePrint.Mypickup, ColumnIndex_forCoinToCall);
    }


    public GameObject ConstructColumn(int argx, MyEnums.Season argEason, MyEnums.Pickup argPickup, int idforcoin)
    {
        if (argEason == MyEnums.Season.Spring) { CurrSeasonTile = GrassTiles; }
        else if (argEason == MyEnums.Season.Winter) { CurrSeasonTile = SnowTiles; }
        else if (argEason == MyEnums.Season.Fall) { CurrSeasonTile = FallTiles; }

        GameObject Column = new GameObject();
        GameObject Dirt = null;
        GameObject Flat = null;
        GameObject CornerUPhill = null;
        GameObject CornerDownhill = null;

        GameObject Hillup = null;
        GameObject HIllDown = null;
        GameObject Seawater = null;
        GameObject Cointemp = null;
        switch (argx)
        {

            case -1:
                Seawater = Instantiate(TileWater_Sea);
                Seawater.transform.position += new Vector3(0, 0 * TileSize, 0);
                Seawater.transform.parent = Column.transform;
                Seawater.transform.GetChild(0).GetComponent<TextMesh>().text = "";
                break;
            case 0:
                Flat = Instantiate(CurrSeasonTile[0]);
                Flat.transform.position += new Vector3(0, 0 * TileSize, 0);
                Flat.transform.parent = Column.transform;
                Flat.transform.GetChild(0).GetComponent<TextMesh>().text = "";

                if (argPickup == MyEnums.Pickup.CoinPickup)
                {
                    Cointemp = Instantiate(CoinObj);
                    Cointemp.transform.position += new Vector3(0, 1 * TileSize, 0);
                    Cointemp.transform.parent = Column.transform;
                    Cointemp.GetComponent<CoinLandScrol>().ID_ofvisibleColumn = idforcoin;
                }

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

                if (argPickup == MyEnums.Pickup.CoinPickup)
                {
                    Cointemp = Instantiate(CoinObj);
                    Cointemp.transform.position += new Vector3(0, 2 * TileSize, 0);
                    Cointemp.transform.parent = Column.transform;
                    Cointemp.GetComponent<CoinLandScrol>().ID_ofvisibleColumn = idforcoin;

                }
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


                if (argPickup == MyEnums.Pickup.CoinPickup)
                {
                    Cointemp = Instantiate(CoinObj);
                    Cointemp.transform.position += new Vector3(0, 3 * TileSize, 0);
                    Cointemp.transform.parent = Column.transform;
                    Cointemp.GetComponent<CoinLandScrol>().ID_ofvisibleColumn = idforcoin;

                }
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
        Column.name = "state_" + argx;
        return Column;
    }




}