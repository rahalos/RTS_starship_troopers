using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScr : MonoBehaviour
{

    float range = 2;
    public float CurrCoolDown, CoolDown;

    public GameObject projectile;

    private void Update()
    {

        if (CanShoot())
            SearchTarget();
        
        if (CurrCoolDown > 0)
            CurrCoolDown -= Time.deltaTime;
    }


    bool CanShoot()
    {
        if (CurrCoolDown <= 0)
            return true;
        return false;

    }
    


   
    void SearchTarget()
    {
        Transform nearesEnemy = null;
        float nearesEnemyDistance = Mathf.Infinity;


        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
        {
            float currDistance = Vector2.Distance(transform.position, enemy.transform.position);


            if(currDistance < nearesEnemyDistance && currDistance <= range)
            {
                nearesEnemy = enemy.transform;
                nearesEnemyDistance = currDistance;
            }
        }

        if (nearesEnemy != null)
            Shoot(nearesEnemy);

    }
    

    void Shoot(Transform enemy)
    {
        CurrCoolDown = CoolDown;

        GameObject proj = Instantiate(projectile);
        proj.transform.position = transform.position;
        proj.GetComponent<ProjecttileScr>().SetTarget(enemy);
        Debug.Log("Shoot");
    }

}
