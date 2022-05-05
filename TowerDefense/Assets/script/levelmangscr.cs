using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmangscr : MonoBehaviour
{

    public int fieldWidth, fieldHeight;

    public GameObject CellPref;
    public Transform CellParent;
    public Sprite[] tileSpr = new Sprite[2];

    public List<GameObject> waypoints = new List<GameObject>();
    GameObject[,] allCells = new GameObject[11, 20];
    int currWayX, currWayY;
    GameObject firstCell;

    string[] path = { "00100000000000000000",
                      "00100000000000000000",
                      "00111100000000000000",
                      "00000100000000000000",
                      "00000111111111000000",
                      "00000000000001000000",
                      "00000000000111000000",
                      "00000001111100000000",
                      "00000001000000000000",
                      "00000001111111111100",
                      "00000000000000000100",
                                            };


    void Start()
    {
        CreateLevel();
        LoadWaypoints();
    }

    void CreateLevel()
    {
        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        for (int i = 0; i < fieldHeight; i++)
            for (int k = 0; k < fieldWidth; k++)
            {



                int sprIndex = int.Parse(path[i].ToCharArray()[k].ToString());
                Sprite spr = tileSpr[sprIndex];

                bool isGround = spr == tileSpr [1] ? true : false;

                CreateCell(isGround, spr, k, i, worldVec);

            }


    }

    void CreateCell(bool isGround,Sprite spr, int x, int y, Vector3 wV)
    {
        GameObject tmpCell = Instantiate(CellPref);
        tmpCell.GetComponent<SpriteRenderer>().sprite = spr;

        tmpCell.transform.SetParent(CellParent, false);
        float sprSizeX = tmpCell.GetComponent<SpriteRenderer>().bounds.size.x;
        float sprSizeY = tmpCell.GetComponent<SpriteRenderer>().bounds.size.y;

        tmpCell.transform.position = new Vector3(wV.x + (sprSizeX + x), wV.y + (sprSizeY * -y));

        if (isGround)
        {
            //Debug.Log ("gotcha");
            tmpCell.GetComponent<CellScr>().isGround = true;
            if (firstCell == null)
            {
                firstCell = tmpCell;
                currWayX = x;
                currWayY = y;
            }
            //Debug.Log (currWayX);
            //Debug.Log (currWayY);
        }
        allCells[y, x] = tmpCell;
    }


    void LoadWaypoints()
    {
        GameObject currWayTo;
        waypoints.Add(firstCell);
        //Debug.Log (first_Cell);
        //Debug.Log (waypoints);
        while (true)
        {
            currWayTo = null;
            if (currWayX > 0 && allCells[currWayY, currWayX - 1].GetComponent<CellScr>().isGround &&
                !waypoints.Exists(x => x == allCells[currWayY, currWayX - 1]))
            {
                currWayTo = allCells[currWayY, currWayX - 1];
                currWayX--;
                //Debug.Log ("To left");
            }
            else if (currWayX < (fieldHeight - 1) && allCells[currWayY, currWayX + 1].GetComponent<CellScr>().isGround &&
                !waypoints.Exists(x => x == allCells[currWayY, currWayX + 1]))
            {
                currWayTo = allCells[currWayY, currWayX + 1];
                currWayX++;
                //Debug.Log ("To right");
            }
            else if (currWayY > 0 && allCells[currWayY - 1, currWayX].GetComponent<CellScr>().isGround &&
                !waypoints.Exists(x => x == allCells[currWayY - 1, currWayX]))
            {
                currWayTo = allCells[currWayY - 1, currWayX];
                currWayY--;
                //Debug.Log ("To up");
            }
            else if (currWayY < (fieldHeight - 1) && allCells[currWayY + 1, currWayX].GetComponent<CellScr>().isGround &&
                !waypoints.Exists(x => x == allCells[currWayY + 1, currWayX]))
            {
                currWayTo = allCells[currWayY + 1, currWayX];
                currWayY++;
                //Debug.Log ("To down");
            }
            else
                break;
            waypoints.Add(currWayTo);
        }


    }
}