using UnityEngine;
using UnityEngine.UI;

public class LeverRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public AudioClip crankSound;
    public Text timerText;

    private bool isGrabbed = false;
    private bool isTimerRunning = false;
    private float timerDuration;
    public float timer;
    private float remainingTime;

    private AudioSource audioSource;

    public delegate void SelectEndingDelegate();
    public event SelectEndingDelegate SelectEndingEvent;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = crankSound;
    }

    void Update()
    {
        if (isGrabbed)
        {
            // Rotate the lever in the negative Z-axis.
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

                if (!isTimerRunning)
                {
                    StartTimer();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrabbed = false;
            if (isTimerRunning)
            {
                PauseTimer();
            }
        }

        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isTimerRunning = false;
                Debug.Log("Time's up");
                SelectEnding(); // Call the function to select the ending.
            }

            timerText.text = "Time: " + timer.ToString("F1");
        }
    }

    void OnMouseDown()
    {
        isGrabbed = true;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (!isTimerRunning)
        {
            StartTimer();
        }
    }

    void StartTimer()
    {
        if (!isTimerRunning)
        {
            // Start the timer only if it's not running.
            isTimerRunning = true;
            if (remainingTime <= 0)
            {
                // If remaining time is not set, select a random duration.
                timerDuration = Random.Range(11.0f, 12.0f);
            }
            timer = remainingTime > 0 ? remainingTime : timerDuration;
        }
    }

    void PauseTimer()
    {
        if (isTimerRunning)
        {
            // Pause the timer only if it's running.
            remainingTime = timer;
            isTimerRunning = false;
        }
    }

    void SelectEnding()
    {
        // Call a function or perform actions to select an ending.
        // For now, let's print a message to the console.
        Debug.Log("Selecting ending...");

        // Trigger the event to handle the ending selection in another script.
        if (SelectEndingEvent != null)
        {
            SelectEndingEvent.Invoke();
        }
    }
}
