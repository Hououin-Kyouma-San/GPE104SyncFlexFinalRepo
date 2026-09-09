using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject pauseDisplay;

    // Disables pause menu and starts game time
    public void ResumeGame()
    {
        pauseDisplay.SetActive(false);
        Time.timeScale = 1.0f;
    }
}