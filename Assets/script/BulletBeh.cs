using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

    private GameManagerLabel gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerLabel>();
    }

    // Update is called once per frame
    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // 2 
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                // 3
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar_ex healthBar =
                    healthBarTransform.gameObject.GetComponent<HealthBar_ex>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                // 4
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                  //  AudioSource audioSource = target.GetComponent<AudioSource>();
                   // AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    gameManager.Points += 50;
                }
            }
            Destroy(gameObject);
        }
    }
}
