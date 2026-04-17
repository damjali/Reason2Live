using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [Header("Component")]
    private Light2D myLight;
    public Slider batteryBar;

    [Header("Battery Settings")]
    public float maxBattery = 100f;
    public float currentBattery; // Ini nilai bateri semasa
    public float drainRate = 2f; // Kelajuan bateri turun

    [Header("Flashlight Settings")]
    public float maxRadius = 20f;
    public float minRadius = 1f;

    void Start()
    {
        myLight = GetComponentInChildren<Light2D>();
        // 1. MULA DARI FULL (Start from full)
        currentBattery = maxBattery;

        // Setup UI Slider
        if (batteryBar != null)
        {
            batteryBar.maxValue = maxBattery;
            batteryBar.value = currentBattery;
        }
    }

    void Update()
    {
        // 2. BATERI SLOWLY TURUN (Decrease)
        // Di sinilah kod yang buat bateri berkurang setiap saat
        if (currentBattery > 0)
        {
            // Time.deltaTime buatkan ia turun secara smooth, bukan mengejut
            currentBattery -= drainRate * Time.deltaTime; 
        }


        UpdateLight();
        UpdateBattery();
    }

    void UpdateLight()
    {
        float percentage = currentBattery / maxBattery;

        // FLASHLIGHT FOLLOW THE BATTERY VALUE
        if (myLight != null)
        {
 
            myLight.pointLightOuterRadius = Mathf.Lerp(minRadius, maxRadius, percentage);
            
            // Cahaya akan malap ikut percentage
            myLight.intensity = Mathf.Lerp(0.1f, 1f, percentage);
        }

        
    }

    void UpdateBattery(){
        // UI BAR FOLLOW THE BATTERY VALUE
        if (batteryBar != null)
        {
            batteryBar.value = currentBattery;
        }
    }

    public void AddBattery(float amount) {
        currentBattery += amount;

        if (currentBattery > maxBattery) {
            currentBattery = maxBattery;
        }

        UpdateLight();
        UpdateBattery();
    }
}