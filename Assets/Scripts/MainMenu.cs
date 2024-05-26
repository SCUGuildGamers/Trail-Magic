using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public void StartGame()
    {
        // Move the player to the starting position
        // This can only be implemented once MainMenu is in the same scene
        
        // Load the scene
        SceneManager.LoadScene(playerData.checkpoint);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
