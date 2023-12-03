using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public GameObject panel1; // Reference to Panel 1 in the Inspector.
    public GameObject panel2; // Reference to Panel 2 in the Inspector.
    public GameObject goodEndingPrefab; // Reference to the prefab for the good ending.
    public GameObject badEndingPrefab; // Reference to the prefab for the bad ending.

    public Transform spawnPoint; // Reference to the spawn point in the Inspector.

    void Start()
    {
        // Subscribe to the event to select the ending when the timer reaches 0.
        LeverRotation leverScript = FindObjectOfType<LeverRotation>();
        leverScript.SelectEndingEvent += OnSelectEnding;
    }

    void OnSelectEnding()
    {
        // This function is called when the timer reaches 0 and an ending is selected.
        // Replace this logic with your ending selection criteria.
        int endingChoice = Random.Range(1, 3); // Randomly select between ending 1 and ending 2.

        // Show the appropriate panel based on the ending choice.
        if (endingChoice == 1)
        {
            ShowPanel(panel1);
            SpawnPrefab(goodEndingPrefab);
        }
        else if (endingChoice == 2)
        {
            ShowPanel(panel2);
            SpawnPrefab(badEndingPrefab);
        }
    }
    void ShowPanel(GameObject panel)
    {
        StartCoroutine(ShowPanelWithDelay(panel, 2f));
        StartCoroutine(ChangeScene(6.2f));
    }

    IEnumerator ChangeScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Load the MenuScene after the specified delay.
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator ShowPanelWithDelay(GameObject panel, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Set the specified panel as active (visible) after the delay.
        panel.SetActive(true);
    }


    void SpawnPrefab(GameObject prefab)
    {
        // Instantiate the specified prefab at the spawn point's position and rotation.
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
