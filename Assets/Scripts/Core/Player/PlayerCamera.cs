using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCamera : MonoBehaviour
{
    public Transform cameraOrientation;
    public TextMeshProUGUI sensitivityCounter;
    //public Image sensitivityBar;
    float cameraSpeedX;
    float cameraSpeedY;
    float currentSensitivity;
    public float cameraSensitivity;
    //public float maxSensitivity = 1000.0f;
    float xRotation;
    float yRotation;

    public void CameraSensitivity()
    {
        currentSensitivity = cameraSensitivity;
    }
    public void UpdateSensitivityCounter()
    {
        if (sensitivityCounter != null)
        {
            sensitivityCounter.text = "" + (Mathf.Round(cameraSensitivity * 1)) / 100;
        }
    }
    private void Start()
    {
        // Locks the cursor and disables cursor visibility
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CameraSensitivity();
    }
    private void LateUpdate()
    {
        // Gets the mouse inputs of the player, on both the X and Y axis planes
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * /*cameraSpeedX*/ currentSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * /*cameraSpeedY*/ currentSensitivity;
        // Assigns the X and Y rotations to the X and Y axis inputs
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        // Controls rotation and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        cameraOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        UpdateSensitivityCounter();
    }
}