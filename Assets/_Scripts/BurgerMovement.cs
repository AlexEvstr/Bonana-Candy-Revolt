using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!BurgersCounter.isFinished)
            transform.Translate(Vector2.left * Time.deltaTime * 1);
    }
}
