using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveEnemy : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = SpawnEnemy.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
           
        void GetNextWaypoint()
        {

            

            if (wavepointIndex >= SpawnEnemy.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }


            wavepointIndex++;
            target = SpawnEnemy.points[wavepointIndex];
        }


    


    }

}
