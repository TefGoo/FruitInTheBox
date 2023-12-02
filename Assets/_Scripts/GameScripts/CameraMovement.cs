using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public LeverRotation leverRotation;
    public float forwardSpeed = 1.0f;

    void Start()
    {
        if (leverRotation == null)
        {
            leverRotation = FindObjectOfType<LeverRotation>();
        }
    }

    void Update()
    {
        if (leverRotation != null && leverRotation.isGrabbed)
        {
            // Move the camera forward when the lever is being rotated.
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }
}
