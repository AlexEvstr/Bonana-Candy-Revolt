using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.deltaTime * 0.5f);
    }
}
