using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject pauseDisplay;
    [SerializeField] private GameObject settingsDisplay;
    private float currentSensitivity;
    private float maxSensitivity;
    public TextMeshProUGUI sensitivityCounter;
    public Image sensitivityBar;
    public Scrollbar sensitivityScrollbar;

    // Disables pause menu, starts game time, amd disables cursor
    public void ChangeSettings()
    {
        pauseDisplay.SetActive(false);
        settingsDisplay.SetActive(true);
    }
    public void CameraSensitivity()
    {
        FindFirstObjectByType<PlayerCamera>().cameraSensitivity = currentSensitivity;
    }
    public void UpdateSensitivityCounter()
    {
        if (sensitivityCounter != null)
        {
            maxSensitivity = FindFirstObjectByType<PlayerCamera>().maxSensitivity;
            sensitivityCounter.text = "" + (Mathf.Round(FindFirstObjectByType<PlayerCamera>().cameraSensitivity * 1)) / 100;
            sensitivityBar.fillAmount = currentSensitivity / maxSensitivity;
        }
    }
    public void ChangeSensitivity(Scrollbar amount)
    {
        float currentValue = amount.value * 1000;
        currentSensitivity = currentValue;
        CameraSensitivity();
    }
    public void Update()
    {
        UpdateSensitivityCounter();
    }
}