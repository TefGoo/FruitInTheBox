using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject panel1; // Reference to Panel 1 in the Inspector.
    public GameObject panel2; // Reference to Panel 2 in the Inspector.

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
        }
        else if (endingChoice == 2)
        {
            ShowPanel(panel2);
        }
    }

    void ShowPanel(GameObject panel)
    {
        // Set the specified panel as active (visible).
        panel.SetActive(true);
    }
}
