using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScr : MonoBehaviour
{
    public int state, id;

    public Color norCol, pathCol;

    private void Start()
    {
        
    }

    public void SetState(int i)
    {
        state = i;

        if(i == 0)
            GetComponent<Image>().color = norCol;
        if (i == 1)
            GetComponent<Image>().color = pathCol;
        
    }

}
