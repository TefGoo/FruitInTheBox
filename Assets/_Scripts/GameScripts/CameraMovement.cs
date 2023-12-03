using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public LeverRotation leverRotation;
    public float forwardSpeed = 1.0f;

    private bool canMove = true; // New flag

    void Start()
    {
        if (leverRotation == null)
        {
            leverRotation = FindObjectOfType<LeverRotation>();
        }
    }

    void Update()
    {
        if (canMove && leverRotation != null && leverRotation.isGrabbed)
        {
            // Move the camera forward when the lever is being rotated.
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }
}
