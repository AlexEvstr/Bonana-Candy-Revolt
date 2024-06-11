using UnityEngine;

public class GameVibroAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clickAudioClip;
    private AudioSource audioPlayer;
    public static bool isVibrationEnabled;

    private void Awake()
    {
        Vibration.Init();
        int vibrationSetting = PlayerPrefs.GetInt("vibrationSetting", 1);
        isVibrationEnabled = vibrationSetting == 1;
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayClickFeedback()
    {
        audioPlayer.PlayOneShot(clickAudioClip);
        if (isVibrationEnabled)
        {
            Vibration.VibrateIOS(ImpactFeedbackStyle.Soft);
        }
    }
}