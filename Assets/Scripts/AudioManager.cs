using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // This makes it easy to call from ANY other script
    public static AudioManager instance;

    public AudioSource sfxSource;

    [Header("Your Audio Clips")]
    public AudioClip bunyiJantung;
    public AudioClip collectMedicine; // Changed this!
    public AudioClip bilaMati;

    void Awake()
    {
        // Set up the instance
        if (instance == null)
            instance = this;
    }

    // Call this when the heartbeat happens
    public void PlayHeartbeat()
    {
        sfxSource.PlayOneShot(bunyiJantung);
    }

    // Call this when Player 1 touches the medicine
    public void PlayMedicineSound() // Changed the name here!
    {
        sfxSource.PlayOneShot(collectMedicine); // And here!
    }

    // Call this when Player 2 gets caught
    public void PlayDeathSound()
    {
        sfxSource.PlayOneShot(bilaMati);
    }
}