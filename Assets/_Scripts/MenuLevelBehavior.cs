using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevelBehavior : MonoBehaviour
{
    private Button _choice;
    private Image _opinion;
    private int level;

    private void Start()
    {
        StartBehavior();
    }

    private void StartBehavior()
    {
        _choice = GetComponent<Button>();
        _opinion = GetComponent<Image>();

        if (_choice == null || _opinion == null || !int.TryParse(gameObject.name, out level))
        {
            return;
        }

        int bestLvl = PlayerPrefs.GetInt("bestLevel", 1);
        if (bestLvl < level)
        {
            _choice.enabled = false;
            _opinion.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            _choice.enabled = true;
            _opinion.color = new Color(1f, 1f, 1f);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void LevelPick()
    {
        if (int.TryParse(gameObject.name, out level))
        {
            PlayerPrefs.SetInt("currentLevel", level);
            SceneManager.LoadScene("GameScene");
        }
    }
}