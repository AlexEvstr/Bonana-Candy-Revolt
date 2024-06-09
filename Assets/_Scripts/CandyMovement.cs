using UnityEngine;

public class CandyMovement : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    private SpriteRenderer _candy;
    
    private void Start()
    {
        _candy = GetComponent<SpriteRenderer>();
        _candy.sprite = _sprites[int.Parse(PlayerPrefs.GetString("Candy", "0"))];
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 5);
    }
}