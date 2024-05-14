using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool PausedGame = false;


    public GameObject pausemneuUI;
  

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausedGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pausemneuUI.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;
    }

    void Pause()
    {
        pausemneuUI.SetActive(true);
        Time.timeScale = 0f;
        PausedGame=true;
    }
}
