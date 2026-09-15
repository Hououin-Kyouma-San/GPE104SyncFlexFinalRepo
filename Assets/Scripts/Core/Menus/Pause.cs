using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private GameObject pauseDisplay;
    [SerializeField] private GameObject settingsDisplay;
    [SerializeField] bool menuSwitch;

    // Disables pause settings menu before game starts
    private void Awake()
    {
        pauseDisplay.SetActive(false);
    }
    // Enables menu, freezes time, enables cursor, and disables menuSwitch
    public void PauseGame()
    {
        pauseDisplay.SetActive(true); 
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menuSwitch = false;
    }
    // Enables pause key when menuSwitch boolean is true
    private void Update()
    {
        if (menuSwitch != false)
        {
            if (Input.GetKeyDown(pauseKey))
            {
                PauseGame();
            }
        }
    }
    // Enables menuSwitch boolean if pauseDisplay is active
    private void FixedUpdate()
    {
        if (pauseDisplay == isActiveAndEnabled)
        {
            menuSwitch = true;
        }
    }
}