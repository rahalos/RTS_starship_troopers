using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using System;


public class GridBuildingSystem : MonoBehaviour
{

    public static GridBuildingSystem current;


    public GridLayout gridLayout;
    public Tilemap MainTilemap;
    public Tilemap Temptilemap;

    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();


    private Building temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;

    #region  Unity Methods

    private void Awake()
    {
        current = this;   
    }

    private void Start()
    {
        string titlePath = @"Title\";
        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.White, Resources.Load<TileBase>(titlePath + "white"));
        tileBases.Add(TileType.Green, Resources.Load<TileBase>(titlePath + "grenn"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>(titlePath + "red"));
    }

    private void Update()
    {
        
        if (!temp)
        {
            return;

        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject(0))
            {

            }

            if (!temp.Placed)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridLayout.LocalToCell(touchPos);

                if(prevPos != cellPos)
                {
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos
                        + new Vector3(0f, 0f , 0f));
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }

        }



    }

    #endregion


    #region Tilemap Management

 

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;


        foreach (var v in area.allPositionsWithin)

        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;


        }

        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);

        tilemap.SetTilesBlock(area, tileArray);
    }

    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }

    #endregion


    #region Bulding Placement

    public void InitializeWithBulding(GameObject building)
    {
        temp = Instantiate(building, Vector3.zero, Quaternion.identity).GetComponent<Building>();
        
    
    }

    private void ClearArea()
    {

        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y + prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        Temptilemap.SetTilesBlock(prevArea, toClear);


    }

    private void FollowBuilding()
    {
        ClearArea();

        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, MainTilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < baseArray.Length; i++)
        {
            if (baseArray[i] == tileBases[TileType.White])
            {
                tileArray[i] = tileBases[TileType.Green];
            }
            else
            {
                FillTiles(tileArray, TileType.Red);
                break;

            }
        }

        Temptilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    
            
    }

    #endregion

}



public enum TileType
{
    Empty,
    Green,
    Red,
    White
}