using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
   public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    
}
