using UnityEngine;
using System.Collections;

public class SmoothRotationWithSound : MonoBehaviour
{
    public float targetLocalRotationX = -90f;
    public float rotationSpeed = 20f;
    public AudioClip rotationSound; // Attach your sound effect here

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Invoke the RotateObject method after a delay of 1 second.
        Invoke("RotateObject", 1f);
    }

    void RotateObject()
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
