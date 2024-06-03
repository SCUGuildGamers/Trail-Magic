using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }
    }

    public void StartGame()
    {
        // Move the player to the starting position
        // This can only be implemented once MainMenu is in the same scene
        
        // Load the scene
        FindObjectOfType<FlashEffect>().ButtonPressed(playerData.checkpoint);
        // SceneManager.LoadScene(playerData.checkpoint);

        audioSource.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
