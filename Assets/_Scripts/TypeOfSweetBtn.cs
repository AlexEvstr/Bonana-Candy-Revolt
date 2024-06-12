using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeOfSweetBtn : MonoBehaviour
{
    [SerializeField] private GameObject _clicked;
    [SerializeField] private int _totalCost;
    [SerializeField] private GameObject _cost;
    [SerializeField] private GameObject _choosen;
    [SerializeField] private Image _coockie;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private MenuVibroAudio _menuVibroAudio;


    private void Start()
    {
        string planeName = PlayerPrefs.GetString("Candy", "");
        if (gameObject.name == planeName)
            _clicked.transform.SetParent(gameObject.transform);
    }

    public void PickCandy()
    {
        if (!_choosen.activeInHierarchy)
        {
            MenuController.CurrentBalance -= _totalCost;
            PlayerPrefs.SetInt("Balance", MenuController.CurrentBalance);
            SaveBuyStatus();
            _menuVibroAudio.PlayPurchaseFeedback();
        }
        else
        {
            _menuVibroAudio.PlayClickFeedback();
        }

        PlayerPrefs.SetString("Candy", gameObject.name);
        _clicked.transform.SetParent(gameObject.transform);
        MakeBought();
    }

    private void SaveBuyStatus()
    {
        if (gameObject.name == "0") PlayerPrefs.SetString("candy_0", "unlocked");
        else if (gameObject.name == "1") PlayerPrefs.SetString("candy_1", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("candy_2", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("candy_3", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("candy_4", "unlocked");
        else if (gameObject.name == "2") PlayerPrefs.SetString("candy_5", "unlocked");
    }

    private void Update()
    {
        CheckCandy();
        CheckPrice();
        CheckStatus();
    }

    private void CheckCandy()
    {
        if (gameObject.transform.childCount == 4)
            gameObject.GetComponent<Image>().color = Color.green;
        else
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
    }

    private void CheckPrice()
    {
        if (_totalCost > MenuController.CurrentBalance && !_choosen.activeInHierarchy)
        {
            gameObject.GetComponent<Button>().interactable = false;
            _coockie.color = Color.grey;
            _priceText.color = Color.grey;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            _coockie.color = Color.white;
            _priceText.color = new Color(1, 0.4f, 0.9f, 1);
        }
    }

    private void CheckStatus()
    {
        if (gameObject.name == "0")
        {
            if (PlayerPrefs.GetString("candy_0", "") != "") MakeBought();
        }

        else if (gameObject.name == "1")
        {
            if (PlayerPrefs.GetString("candy_1", "") != "") MakeBought();
        }

        else if (gameObject.name == "2")
        {
            if (PlayerPrefs.GetString("candy_2", "") != "") MakeBought();
        }
        else if (gameObject.name == "3")
        {
            if (PlayerPrefs.GetString("candy_3", "") != "") MakeBought();
        }
        else if (gameObject.name == "4")
        {
            if (PlayerPrefs.GetString("candy_4", "") != "") MakeBought();
        }
        else if (gameObject.name == "5")
        {
            if (PlayerPrefs.GetString("candy_5", "") != "") MakeBought();
        }

    }

    private void MakeBought()
    {
        _cost.SetActive(false);
        _choosen.SetActive(true);
    }
}