using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class placetower : MonoBehaviour
{


    public GameObject TowerPrefab;
    private GameObject Tower;
    private GameManagerLabel gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerLabel>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private bool CanPlaceTower()
    {
        int cost =TowerPrefab.GetComponent<TowerData>().levels[0].cost;
        return Tower == null && gameManager.Points >= cost;
    }

    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            //3
            Tower = (GameObject)Instantiate(TowerPrefab, transform.position, Quaternion.identity);
            //4
            /*
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            */

            gameManager.Points -= Tower.GetComponent<TowerData>().CurrentLevel.cost;

        }
        else if (CanUpgradeTower())
        {
            Tower.GetComponent<TowerData>().IncreaseLevel();
            /*
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);*/
            // TODO: вычитать золото
            gameManager.Points -= Tower.GetComponent<TowerData>().CurrentLevel.cost;
        }

  
    }

    private bool CanUpgradeTower()
    {
        if (Tower != null)
        {
            TowerData towerData = Tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Points >= nextLevel.cost;
            }
        }
        return false;
    }

}
