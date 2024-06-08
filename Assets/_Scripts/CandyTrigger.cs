using UnityEngine;

public class CandyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Burger"))
        {
            Destroy(collision.gameObject);
            BurgersCounter.BurgersCount++;
            Destroy(gameObject);
        }
    }
}