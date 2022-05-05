using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   public TowenBtn clickedBtn { get; private set; }
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
       
    }

    public void PickTower(TowenBtn towenBtn)
    {
        this.clickedBtn = towenBtn;
    }

    public void buyTower()
    {
        clickedBtn = null;
    }

}
