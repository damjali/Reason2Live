using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlackoutScare : MonoBehaviour
{
    [Header("Core Scripts & Lights")]
    public Flashlight playerBatteryScript; // Reference to your Flashlight script to check battery
    public Light2D globalLight;            // The map's main light
    public Light2D playerSpotlight;        // The new spotlight on the player
    public Light2D monsterRedLight;        // The red spotlight on the monster

    [Header("Scare Settings")]
    public float blackoutDuration = 1f;    // How long the map stays pitch black
    public float blinkSpeed = 0.2f;        // How fast the monster's light blinks
    public float playerLightIntensity = 1f; // How bright the player's spotlight gets
    public float monsterLightIntensity = 2f; // How bright the monster's red light gets

    private bool hasTriggered = false;     // To make sure this only happens ONCE

    void Start()
    {
        // Ensure both event lights are OFF when the game starts
        if (playerSpotlight != null) playerSpotlight.intensity = 0f;
        if (monsterRedLight != null) monsterRedLight.intensity = 0f;
    }

    void Update()
    {
        // Check if battery is dead and the event hasn't started yet
        if (playerBatteryScript != null && playerBatteryScript.currentBattery <= 0 && !hasTriggered)
        {
            StartCoroutine(ExecuteScareSequence());
        }
    }

    IEnumerator ExecuteScareSequence()
    {
        hasTriggered = true; // Lock the event so it doesn't trigger a million times

        // --- PHASE 1: THE BLACKOUT ---
        if (globalLight != null) 
        {
            globalLight.intensity = 0f; // Turn off the sun!
        }
        
        // Wait in pitch darkness for exactly 1 second
        yield return new WaitForSeconds(blackoutDuration);

        // --- PHASE 2: PLAYER SPOTLIGHT ON ---
        if (playerSpotlight != null)
        {
            playerSpotlight.intensity = playerLightIntensity;
        }

        // --- PHASE 3: MONSTER BLINKING LOOP ---
        // This while(true) loop will run forever until the game ends or scene changes
        while (true) 
        {
            // Monster light ON
            if (monsterRedLight != null) monsterRedLight.intensity = monsterLightIntensity;
            yield return new WaitForSeconds(blinkSpeed);

            // Monster light OFF
            if (monsterRedLight != null) monsterRedLight.intensity = 0f;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}