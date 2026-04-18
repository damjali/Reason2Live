using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource sfxSource;

    [Header("The Master Switch")]
    public static bool useVoiceSFX = false; // False = Normal, True = Your Voices

    [Header("Normal Audio Clips")]
    public AudioClip normalJantung;
    public AudioClip normalMedicine;
    public AudioClip normalMati;
    // Add two more normal ones here to hit the 5 required!

    [Header("Voice Audio Clips (Best SFX!)")]
    public AudioClip voiceJantung;
    public AudioClip voiceMedicine;
    public AudioClip voiceMati;
    // Add two more voice ones here!

    void Awake()
    {
        if (instance == null)
            instance = this;
            
    }

    // --- UI TOGGLE METHOD ---
    // The UI button will call this to flip the switch
    public void SetVoiceSFX(bool isToggled)
    {
        useVoiceSFX = isToggled;
        Debug.Log("BEST SFX Mode is now: " + useVoiceSFX);
    }

    // --- PLAY METHODS ---
    public void PlayHeartbeat()
    {
        // Choose the clip based on the toggle
        AudioClip clipToPlay = useVoiceSFX ? voiceJantung : normalJantung;
        sfxSource.PlayOneShot(clipToPlay);
    }

    public void PlayMedicineSound()
    {
        AudioClip clipToPlay = useVoiceSFX ? voiceMedicine : normalMedicine;
        sfxSource.PlayOneShot(clipToPlay);
    }

    public void PlayDeathSound()
    {
        AudioClip clipToPlay = useVoiceSFX ? voiceMati : normalMati;
        sfxSource.PlayOneShot(clipToPlay);
    }
}