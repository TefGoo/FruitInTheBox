using UnityEngine;

public class LeverRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public AudioClip crankSound;

    private bool isGrabbed = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent <AudioSource>();
        audioSource.clip = crankSound;
    }

    void Update()
    {
        if (isGrabbed)
        {
            // Rotate the crank in the negative Z-axis.
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!isGrabbed)
            {
                isGrabbed = true;
                if (!audioSource.isPlaying)
                {
                    audioSource.UnPause();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrabbed = false;
        }
    }

    void OnMouseDown()
    {
        isGrabbed = true;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}