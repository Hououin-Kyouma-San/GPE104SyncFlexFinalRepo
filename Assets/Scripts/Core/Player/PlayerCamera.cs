using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraOrientation;
    public float cameraSensitivityX;
    public float cameraSensitivityY;
    float xRotation;
    float yRotation;

    private void Start()
    {
        // Locks the cursor and disables cursor visibility
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        // Gets the mouse inputs of the player, on both the X and Y axis planes
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraSensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraSensitivityY;
        // Assigns the X and Y rotations to the X and Y axis inputs
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        // Controls rotation and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        cameraOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}