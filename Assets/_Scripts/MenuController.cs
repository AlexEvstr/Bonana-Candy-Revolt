using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _levels;
    [SerializeField] private TMP_Text _MoneyText;
    public static int CurrentBalance;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        CurrentBalance = PlayerPrefs.GetInt("Balance", 0);
        _MoneyText.text = $"{CurrentBalance}";
    }

    public void OpenLevels()
    {
        _menu.SetActive(false);
        _levels.SetActive(true);
    }

    public void CloseLevels()
    {
        _levels.SetActive(false);
        _menu.SetActive(true);
    }
}
