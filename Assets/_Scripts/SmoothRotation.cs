using UnityEngine;
using System.Collections;

public class SmoothRotationWithSound : MonoBehaviour
{
    public float targetLocalRotationX = -90f;
    public float rotationSpeed = 20f;
    public AudioClip rotationSound; // Attach your sound effect here

    private AudioSource audioSource;
    private LeverRotation leverScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        leverScript = FindObjectOfType<LeverRotation>();

        // Subscribe to the event to rotate the object when the timer reaches 0.
        if (leverScript != null)
        {
            leverScript.SelectEndingEvent += OnSelectEnding;
        }
    }

    void OnSelectEnding()
    {
        // Play the sound effect before rotating.
        if (rotationSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(rotationSound);
        }

        // Smoothly rotate the object locally to the target rotation on the X-axis.
        StartCoroutine(RotateCoroutine());
    }

    IEnumerator RotateCoroutine()
    {
        while (Mathf.Abs(transform.localEulerAngles.x - targetLocalRotationX) > 0.01f)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(targetLocalRotationX, 0f, 0f), step);
            yield return null;
        }
    }
}
