using UnityEngine;

public class MenuVibroAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clickAudioClip;
    [SerializeField] private AudioClip purchaseAudioClip;
    private AudioSource audioPlayer;
    public static bool isVibrationEnabled;

    [SerializeField] private GameObject soundEnabledIcon;
    [SerializeField] private GameObject soundDisabledIcon;
    [SerializeField] private GameObject vibrationEnabledIcon;
    [SerializeField] private GameObject vibrationDisabledIcon;

    private void Awake()
    {
        Vibration.Init();
        audioPlayer = GetComponent<AudioSource>();

        int vibrationSetting = PlayerPrefs.GetInt("vibrationSetting", 1);
        isVibrationEnabled = vibrationSetting == 1;

        int soundSetting = PlayerPrefs.GetInt("soundSetting", 1);
        if (soundSetting == 1)
            EnableSound();
        else
            DisableSound();
    }

    public void PlayClickFeedback()
    {
        audioPlayer.PlayOneShot(clickAudioClip);
        if (isVibrationEnabled)
            Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
    }

    public void PlayPurchaseFeedback()
    {
        audioPlayer.PlayOneShot(purchaseAudioClip);
        if (isVibrationEnabled)
            Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
    }

    public void DisableSound()
    {
        soundEnabledIcon.SetActive(false);
        soundDisabledIcon.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("soundSetting", 0);
    }

    public void EnableSound()
    {
        soundDisabledIcon.SetActive(false);
        soundEnabledIcon.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("soundSetting", 1);
    }

    public void DisableVibration()
    {
        vibrationEnabledIcon.SetActive(false);
        vibrationDisabledIcon.SetActive(true);
        isVibrationEnabled = false;
        PlayerPrefs.SetInt("vibrationSetting", 0);
    }

    public void EnableVibration()
    {
        vibrationDisabledIcon.SetActive(false);
        vibrationEnabledIcon.SetActive(true);
        isVibrationEnabled = true;
        PlayerPrefs.SetInt("vibrationSetting", 1);
    }
}