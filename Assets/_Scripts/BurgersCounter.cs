using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BurgersCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentBurgersText;
    [SerializeField] private GameObject _winPanel;
    public static int BurgersCount;
    public static bool isFinished;
    private int _burgersGoal;

    private void Start()
    {
        BurgersCount = 0;
        //isFinished = false;
        _burgersGoal = LevelController.CurrentLevel * 10;
    }

    private void Update()
    {
        _currentBurgersText.text = $"{BurgersCount}/{_burgersGoal}";
        if (BurgersCount == _burgersGoal && !isFinished)
        {
            isFinished = true;
            _winPanel.SetActive(true);
            LevelController.CurrentLevel++;
            PlayerPrefs.SetInt("currentLevel", LevelController.CurrentLevel);
            GameObject burger = GameObject.FindWithTag("Burger");
            if (burger != null)
            {
                Destroy(burger);
            }  
        } 
    }
}
