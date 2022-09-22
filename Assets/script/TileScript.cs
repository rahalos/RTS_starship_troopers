using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; set; }

    public 


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {


        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
     
        


    }

    /*

    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.clickedBtn != null)
        {


            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        
            
        }
    }

    private void PlaceTower()
    {
        


           GameObject Tower = Instantiate(GameManager.Instance.clickedBtn.TowerPrefab, transform.position, Quaternion.identity);
            //Tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;
            Tower.transform.SetParent(transform);

            GameManager.Instance.buyTower();
        
    }
    */

}
