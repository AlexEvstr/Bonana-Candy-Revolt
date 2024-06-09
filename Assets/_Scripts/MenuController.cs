using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _levels;

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
