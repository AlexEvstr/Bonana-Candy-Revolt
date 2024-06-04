using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyMovement : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.deltaTime * 5);
    }
}
