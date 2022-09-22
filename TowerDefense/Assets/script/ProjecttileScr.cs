using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileScr : MonoBehaviour
{
    Transform target;
    float speed = 10;
    int damage = 30;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {
        
        if(target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < .1f)
            {
                target.GetComponent<MoveEnemy>().TakeDamage(damage);
                Destroy(gameObject);
            }      
            else
            {
                Vector2 dir = target.position - transform.position;

                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
                
        }
        else
        {
            Destroy(gameObject);
        }

    }
}