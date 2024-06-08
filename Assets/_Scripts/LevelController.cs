using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevelText;
    public static int CurrentLevel;

    private void Awake()
    {
        CurrentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        _currentLevelText.text = "lvl:" + CurrentLevel.ToString();
    }
}