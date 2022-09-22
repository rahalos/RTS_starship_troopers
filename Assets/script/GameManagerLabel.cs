using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerLabel : MonoBehaviour
{

    public Text pointLabel;
    private int point;

    public int Points
    {
        get
        {
            return point;
        }
        set
        {
            point = value;
            pointLabel.GetComponent<Text>().text = "Point: " + point;
        }
    }

    public Text waveLabel;
    public GameObject[] nextWaveLabels;

    public bool gameOver = false;

    private int waves;
    public int Waves
    {
        get { return waves; }
        set
        {
            waves = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
            waveLabel.text = "WAVE: " + (waves + 1);
        }
    }



    public Text healthLabel;
    public GameObject[] healthIndicator;

    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            // 1
            if (value < health)
            {
              //  Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            healthLabel.text = "HEALTH: " + health;
            // 2
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
            // 3 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        point = 1000;
        Waves = 0;
        Health = 5;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
