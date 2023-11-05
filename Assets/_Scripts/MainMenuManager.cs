using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Attach your UI buttons to these fields in the Unity Inspector.
    public GameObject playButton;
    public GameObject creditsButton;
    public GameObject exitButton;

    // Load the Play scene when the "Play" button is clicked.
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "PlayScene" with the name of your gameplay scene.
    }

    // Load the Credits scene when the "Credits" button is clicked.
    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScene"); // Replace "CreditsScene" with the name of your credits scene.
    }

    // Close the game when the "Exit Game" button is clicked.
    public void ExitGame()
    {
        Debug.Log("Closing Game...");
        Application.Quit(); // This function will only work in standalone builds, not in the Unity Editor.
    }
}
