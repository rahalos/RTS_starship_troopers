using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoveenemyscr : MonoBehaviour
{
    public float speed = 5f;
    public int health = 30;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = testSpawnscr.points[0];
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



            if (wavepointIndex >= testSpawnscr.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }


            wavepointIndex++;
            target = testSpawnscr.points[wavepointIndex];
        }

      


    }
}