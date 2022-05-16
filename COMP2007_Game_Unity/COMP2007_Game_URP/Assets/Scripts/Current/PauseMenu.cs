using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Bool to set game to paused state
    public static bool gameIsPaused = false;

    //Menu UI
    public GameObject pauseUI; 

    // Update is called once per frame
    void Update()
    {
        //When the player presses the escape key, if the pause menu is active, then resume the game, else display the pause meny
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Setting pause state to false
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    //Setting UI and freezing game time
    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    
    //Loads the start menu scene
    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    //Quits the game
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
