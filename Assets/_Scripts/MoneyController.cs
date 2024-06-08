using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyWinText;
    [SerializeField] private TMP_Text _balanceText;
    private int _currentBalance;
    private int _moneyToIncrease;

    private void Start()
    {
        _currentBalance = PlayerPrefs.GetInt("Balance", 0);
        _balanceText.text = $"{_currentBalance}";
        _moneyToIncrease = LevelController.CurrentLevel * 100;
        Debug.Log(_moneyToIncrease);
    }

    public void IncreaseMoney()
    {
        _currentBalance += _moneyToIncrease;
        PlayerPrefs.SetInt("Balance", _currentBalance);
        _moneyWinText.text = $"+{_moneyToIncrease}";
    }
}