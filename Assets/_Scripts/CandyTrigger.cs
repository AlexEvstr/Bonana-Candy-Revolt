using UnityEngine;

public class CandyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    private GameVibroAudio _gameVibroAudio;

    private void Start()
    {
        _gameVibroAudio = GameObject.FindWithTag("Manager").GetComponent<GameVibroAudio>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            GameObject effect = Instantiate(_destroyEffect);
            effect.transform.position = collision.gameObject.transform.position;
            Destroy(effect, 2);
            _gameVibroAudio.PlayDestroyFeedBack();
            Destroy(collision.gameObject);
            BurgersCounter.BurgersCount++;
            Destroy(gameObject);
        }
    }
}