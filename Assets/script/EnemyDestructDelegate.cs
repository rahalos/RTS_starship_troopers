using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructDelegate : MonoBehaviour
{

    public delegate void EnemyDelegates(GameObject enemy);
    public EnemyDelegates enemyDelegates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        if (enemyDelegates != null)
        {
            enemyDelegates(gameObject);
        }
    }

}
