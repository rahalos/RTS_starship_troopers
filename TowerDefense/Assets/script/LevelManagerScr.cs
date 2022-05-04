using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManagerScr : MonoBehaviour
{

    public int fileWidth, filedheigth;
    public GameObject CellPrefab;

    public Transform cellParent;

    public Sprite[] titleSpr = new Sprite[2];

    string[] path = {"00100000000000000000", 
                     "00111111111111111000",
                     "00000000000000011000",
                     "00000000000000110000",
                     "00000000000111100000",
                     "00000000000100000000",
                     "00001111111100000000",
                     "11111000000000000000",
                     "00000000000000000000" };
    
    void Start()
    {
        CreateLevel();
    }

    void CreateLevel()
    {
        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        for (int i = 0; i < filedheigth; i ++)
            for(int k = 0; k < fileWidth; k ++ )
            {
                int sprIndex = int.Parse(path[i].ToCharArray()[k].ToString());
                    Sprite spr = titleSpr[sprIndex];

                CreateCell(spr, k, i, worldVec);
            }
       


    }

    void CreateCell(Sprite spr, int x, int y, Vector3 wV)
    {
        GameObject tmpCell = Instantiate(CellPrefab);

        tmpCell.transform.SetParent(cellParent, false);

        tmpCell.GetComponent<SpriteRenderer>().sprite = spr;

        float sprSizeX = tmpCell.GetComponent<SpriteRenderer>().bounds.size.x;
        float sprSizeY = tmpCell.GetComponent<SpriteRenderer>().bounds.size.y;

        tmpCell.transform.position = new Vector3(wV.x + (sprSizeX * x),wV.y + (sprSizeY * -y));
    }




}
