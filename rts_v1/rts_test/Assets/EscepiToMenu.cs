using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscepiToMenu : MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);

        }
    }
}
