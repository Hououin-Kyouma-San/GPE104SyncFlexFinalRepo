using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform cameraPosition;
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}