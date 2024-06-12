using UnityEngine;
using TMPro;

public class BurgersCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentBurgersText;
    [SerializeField] private GameObject _winPanel;
    public static int BurgersCount;
    public static bool isFinished;
    private int _burgersGoal;

    private MoneyController _moneyController;
    private GameVibroAudio _gameVibroAudio;
    [SerializeField] private GameObject _pauseBtn;

    private void Start()
    {
        _gameVibroAudio = GetComponent<GameVibroAudio>();
        _moneyController = GetComponent<MoneyController>();
        BurgersCount = 0;
        //isFinished = false;
        _burgersGoal = LevelController.CurrentLevel * 10;
    }

    private void Update()
    {
        _currentBurgersText.text = $"{BurgersCount}/{_burgersGoal}";
        if (BurgersCount == _burgersGoal && !isFinished)
        {
            _pauseBtn.SetActive(false);
            _gameVibroAudio.PlayWinFeedBack();
            isFinished = true;
            _winPanel.SetActive(true);
            LevelController.CurrentLevel++;
            _moneyController.IncreaseMoney();
            PlayerPrefs.SetInt("currentLevel", LevelController.CurrentLevel);
            if (LevelController.CurrentLevel > PlayerPrefs.GetInt("bestLevel", 1))
            {
                PlayerPrefs.SetInt("bestLevel", LevelController.CurrentLevel);
            }
            GameObject burger = GameObject.FindWithTag("Burger");
            if (burger != null)
            {
                Destroy(burger);
            }  
        } 
    }
}