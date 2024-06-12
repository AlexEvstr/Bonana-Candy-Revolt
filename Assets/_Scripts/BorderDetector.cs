using UnityEngine;

public class BorderDetector : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameVibroAudio _gameVibroAudio;
    [SerializeField] private GameObject _pauseBtn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            _pauseBtn.SetActive(false);
            _gameVibroAudio.PlayLoseFeedBack();
            _losePanel.SetActive(true);
            BurgersCounter.isFinished = true;
            GameObject[] burgers = GameObject.FindGameObjectsWithTag("Burger");
            foreach (var item in burgers)
            {
                Destroy(item);
            }
        }
    }
}