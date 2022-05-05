using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();

    int wayIndex = 0;

    int speed = 5;


    private void Start()
    {
        wayPoints = GameObject.Find("Main Camera").GetComponent<GameControllerScr>().wayPoints;
      


    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 dir = wayPoints[wayIndex].transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, wayPoints[wayIndex].transform.position) < 0.3f)
            wayIndex++;
    }


}
