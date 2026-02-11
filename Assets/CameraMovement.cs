using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Adjust sensitivity in the Inspector
    public float xLimit = 45f; // Clamps vertical look angle
    
    private float xRotation = 0f;
    private Transform playerBody; // Reference to the parent Player object

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent.transform; // Get the parent (Player) transform
    }

    void Update()
    {
        // Get mouse input axes (GetAxis of mouse movement does not need Time.deltaTime)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical rotation (clamped)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xLimit, xLimit);

        // Apply vertical rotation to the camera (local rotation)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (applied to the parent Player object)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
