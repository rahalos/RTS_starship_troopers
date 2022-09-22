using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject[] tilePreafbs;

    [SerializeField]
    private Transform map;

    [SerializeField]
    public TextAsset LevelText;


    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
        get { return tilePreafbs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }

    }

    // Start is called before the first frame update
    void Start()
    {



        CreateLevel();



    }

    // Update is called once per frame
    void Update()
    {

    }



    public void TestValue(Point p)
    {
        Debug.Log("Changing value");
        p.X = 3;
    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);
            }
        }


    }

    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tilePreafbs[tileIndex]).GetComponent<TileScript>();


        newTile.Setup(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0), map);



    }

    private string[] ReadLevelText()
    {
        //TextAsset bindData = Resources.Load(LevelText.ToString()) as TextAsset;

        string data = LevelText.text.Replace(Environment.NewLine, string.Empty);

        return data.Split("-");

        //string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        //return data.Split('-');
    }



}
