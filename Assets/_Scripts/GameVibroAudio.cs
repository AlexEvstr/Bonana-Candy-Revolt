using UnityEngine;

public class GameVibroAudio : MonoBehaviour
{
    [SerializeField] private AudioClip clickAudioClip;
    [SerializeField] private AudioClip winAudioClip;
    [SerializeField] private AudioClip loseAudioClip;
    [SerializeField] private AudioClip shotAudioClip;
    [SerializeField] private AudioClip destroyAudioClip;
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

    public void PlayWinFeedBack()
    {
        audioPlayer.PlayOneShot(winAudioClip);
        if (isVibrationEnabled)
        {
            Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
        }
    }

    public void PlayLoseFeedBack()
    {
        audioPlayer.PlayOneShot(loseAudioClip);
        if (isVibrationEnabled)
        {
            Vibration.Vibrate();
        }
    }

    public void PlayShotFeedBack()
    {
        audioPlayer.PlayOneShot(shotAudioClip);
        if (isVibrationEnabled)
        {
            Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
        }
    }

    public void PlayDestroyFeedBack()
    {
        audioPlayer.PlayOneShot(destroyAudioClip);
        if (isVibrationEnabled)
        {
            Vibration.VibrateIOS(ImpactFeedbackStyle.Rigid);
        }
    }
}