using UnityEngine;

public class CandyTrigger : MonoBehaviour
{
    private GameVibroAudio _gameVibroAudio;

    private void Start()
    {
        _gameVibroAudio = GameObject.FindWithTag("Manager").GetComponent<GameVibroAudio>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            _gameVibroAudio.PlayDestroyFeedBack();
            Destroy(collision.gameObject);
            BurgersCounter.BurgersCount++;
            Destroy(gameObject);
        }
    }
}