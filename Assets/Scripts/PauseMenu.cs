using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    private bool isPaused = false;
    [SerializeField] private Reticle reticle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if no menu is open
            if (!pauseMenu.activeSelf && !optionsMenu.activeSelf)
            {
                Pause();
            }
            // if Pause Menu alone is open
            else if (pauseMenu.activeSelf)
            {
                Resume();
            }
            // if Options Menu is open
            else if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);
            }

            /*
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            */
        }
    }

    public void Pause() 
    {
        pauseMenu.SetActive(true);
        inGameMenu.SetActive(true);
        reticle.Locked = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        inGameMenu.SetActive(false);
        reticle.Locked = true;
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void QuitToMainMenu()
    {
        // Load the 
        Time.timeScale = 1f;
        SceneManager.LoadScene(playerData.checkpoint);
    }

    public bool IsPaused
    {
        get { return isPaused; }
    }
}
