using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public void StartGame()
    {
        // Load the scene
        SceneManager.LoadScene(playerData.checkpoint);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
