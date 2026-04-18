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
    public AudioClip normalBearSpeak; // Added Bear

    [Header("Voice Audio Clips (Best SFX!)")]
    public AudioClip voiceJantung;
    public AudioClip voiceMedicine;
    public AudioClip voiceMati;
    public AudioClip voiceBearSpeak; // Added Bear

    void Awake()
    {
        if (instance == null)
            instance = this;
            
    }

    // --- UI TOGGLE METHOD ---
    public void SetVoiceSFX(bool isToggled)
    {
        useVoiceSFX = isToggled;
        Debug.Log("BEST SFX Mode is now: " + useVoiceSFX);
    }

    // --- PLAY METHODS ---
    public void PlayHeartbeat()
    {
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

    // Added Bear Play Method
    public void PlayBearSpeak()
    {
        AudioClip clipToPlay = useVoiceSFX ? voiceBearSpeak : normalBearSpeak;
        if(clipToPlay != null) sfxSource.PlayOneShot(clipToPlay);
    }
}