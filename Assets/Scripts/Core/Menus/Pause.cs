using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private GameObject pauseDisplay;

    // Disables pause menu before game starts
    private void Awake()
    {
        pauseDisplay.SetActive(false);
    }
    // Enables pause menu and stops game time
    public void PauseGame()
    {
        pauseDisplay.SetActive(true);
        Time.timeScale = 0.0f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            PauseGame();
        }
    }
}