using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public TextMeshProUGUI sensitivityCounter;
    //public Image sensitivityBar;
    float currentSensitivity;
    //public float maxSensitivity = 1000.0f;




    public void Test()
    {
    }


    public void UpdateSensitivityCounter()
    {
        if (sensitivityCounter != null)
        {
            sensitivityCounter.text = "" + GetComponent<PlayerCamera>().cameraSensitivity;
        }
    }
    void Update()
    {
        Test();
        UpdateSensitivityCounter();
    }
}