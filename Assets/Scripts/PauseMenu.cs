using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused = false;
    [SerializeField] private Reticle reticle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause() 
    {
        inGameMenu.SetActive(true);
        // pauseMenu.SetActive(true);
        reticle.Locked = false;
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        // pauseMenu.SetActive(false);
        inGameMenu.SetActive(false);
        reticle.Locked = true;
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void QuitToMainMenu()
    {
        // Load the scene
        SceneManager.LoadScene(playerData.checkpoint);
    }

    public bool IsPaused
    {
        get { return isPaused; }
    }
}
