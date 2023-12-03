using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject goodEndingPrefab; // Reference to the prefab for the good ending
    public GameObject badEndingPrefab; // Reference to the prefab for the bad ending

    void Start()
    {
        // Subscribe to the SelectEnding event in the LeverRotation script
        LeverRotation leverRotation = FindObjectOfType<LeverRotation>();
        if (leverRotation != null)
        {
            leverRotation.SelectEndingEvent += OnSelectEnding;
        }
    }

    void OnSelectEnding()
    {
        // Check which ending was selected and spawn the corresponding prefab
        if (IsGoodEnding())
        {
            SpawnPrefab(goodEndingPrefab);
        }
        else
        {
            SpawnPrefab(badEndingPrefab);
        }
    }

    bool IsGoodEnding()
    {
        return Random.value > 0.5f; // 50% chance for a good ending
    }

    void SpawnPrefab(GameObject prefab)
    {
        // Spawn the specified prefab at the spawn point's position and rotation
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
