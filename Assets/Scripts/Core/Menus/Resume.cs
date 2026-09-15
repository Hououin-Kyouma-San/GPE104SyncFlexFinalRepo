using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject pauseDisplay;

    // Disables pause menu, starts game time, amd disables cursor
    public void ResumeGame()
    {
        pauseDisplay.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}