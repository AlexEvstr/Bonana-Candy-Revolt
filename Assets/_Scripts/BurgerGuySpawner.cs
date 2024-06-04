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
        BurgersCounter.isFinished = false;
        StartCoroutine(SpawnBurger());
        
    }

    private IEnumerator SpawnBurger()
    {
        while(!BurgersCounter.isFinished)
        {
            yield return new WaitForSeconds(Random.Range(_minTime, _maxTime));
            GameObject newBurgerGuy = Instantiate(_burgerGuy);
            newBurgerGuy.transform.position = new Vector2(4, -3.3f);
        }
    }
}
