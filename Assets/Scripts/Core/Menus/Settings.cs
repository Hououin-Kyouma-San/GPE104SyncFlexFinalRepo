using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject pauseDisplay;
    [SerializeField] private GameObject settingsDisplay;
    public TextMeshProUGUI sensitivityCounter;

    // Disables pause menu, starts game time, amd disables cursor
    public void ChangeSettings()
    {
        pauseDisplay.SetActive(false);
        settingsDisplay.SetActive(true);
    }
}