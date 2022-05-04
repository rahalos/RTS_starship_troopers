using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScr : MonoBehaviour
{
    public int cellCount;

    int[] pathID = { 23, 24, 25, 26, 27, 49, 71, 93, 115 , 116, 117, 118, 119, 120, 142, 164, 165, 166,167, 189, 211, 212, 213, 214, 215, 216, 217, 218 };

    

    public GameObject cellPrefab;
    public Transform cellGroup;

    List<CellScr> AllCells = new List<CellScr>();

    // Start is called before the first frame update
    void Start()
    {
        CreateCells();
        CreatePath();
    }

    void CreateCells()
    {
        for (int i = 0; i < cellCount; i++)
        {
            GameObject tmpCell = Instantiate(cellPrefab);
            tmpCell.transform.SetParent(cellGroup, false);
            tmpCell.GetComponent<CellScr>().id = i + 1;
            tmpCell.GetComponent<CellScr>().SetState(0);
            AllCells.Add(tmpCell.GetComponent<CellScr>());
            

        }
    }

    void CreatePath()
    {
        for (int i = 0; i < pathID.Length; i++)
            AllCells[pathID[i] - 1].SetState(1);
        

        
    }
}
