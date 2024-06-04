using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerGuySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _burgerGuy;

    private float _minTime = 1.2f;
    private float _maxTime = 3.0f;

    private void Start()
    {
        StartCoroutine(SpawnBurger());
        
    }

    private IEnumerator SpawnBurger()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            GameObject newBurgerGuy = Instantiate(_burgerGuy);
            newBurgerGuy.transform.position = new Vector2(3, -3.3f);
        }
    }
}
