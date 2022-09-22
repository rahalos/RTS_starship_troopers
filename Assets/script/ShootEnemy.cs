using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootEnemy : MonoBehaviour
{

    public List<GameObject> enemiesInRanges;

    private float lastShotTimes;
    private TowerData towerData;

    // Use this for initialization
    void Start()
    {
        enemiesInRanges = new List<GameObject>();
        lastShotTimes = Time.time;
        towerData = gameObject.GetComponentInChildren<TowerData>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = null;
        // 1
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRanges)
        {
            float distanceToGoal = enemy.GetComponent<MOVEenemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // 2
        if (target != null)
        {
            if (Time.time - lastShotTimes > towerData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTimes = Time.time;
            }
            // 3
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
                new Vector3(0, 0, 1));
        }
    }

    private void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRanges.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRanges.Add(other.gameObject);
            EnemyDestructDelegate del =
                other.gameObject.GetComponent<EnemyDestructDelegate>();
            del.enemyDelegates += OnEnemyDestroy;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRanges.Remove(other.gameObject);
            EnemyDestructDelegate del =
                other.gameObject.GetComponent<EnemyDestructDelegate>();
            del.enemyDelegates -= OnEnemyDestroy;
        }
    }

    private void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = towerData.CurrentLevel.bullets;
        // 1 
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        // 2 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBeh bulletComp = newBullet.GetComponent<BulletBeh>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;

        // 3 
        Animator animator = towerData.CurrentLevel.visualization.GetComponent<Animator>();
        animator.SetTrigger("fireShot");
        //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        // audioSource.PlayOneShot(audioSource.clip);
    }

}

