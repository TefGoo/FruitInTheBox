using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuManager : MonoBehaviour
{
    // Attach your UI buttons to these fields in the Unity Inspector.
    public GameObject backButton;
    public GameObject exitButton;

    // Load the main menu scene when the "Back" button is clicked.
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MenuScene"); // Replace "MainMenu" with the name of your main menu scene.
    }

    // Close the game when the "Exit Game" button is clicked.
    public void ExitGame()
    {
        Debug.Log("Closing Game...");
        Application.Quit(); // This function will only work in standalone builds, not in the Unity Editor.
    }
}
