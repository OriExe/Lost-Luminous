using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private Animator pauseAnimator;

    private void Start()
    {
        pauseAnimator = GameObject.Find("pause_Menu_UI").GetComponent<Animator>();
        //pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;

            pauseAnimator.SetBool("GamePaused", true);
            pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;

        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        

    }

}
