using UnityEngine;

public class BurgerMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!BurgersCounter.isFinished)
            transform.Translate(Vector2.left * Time.deltaTime * 1);
    }
}