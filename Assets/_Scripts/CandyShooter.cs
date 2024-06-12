using UnityEngine;
using System.Collections;

public class CandyShooter : MonoBehaviour
{
    public GameObject candyPrefab;
    public Transform cannonTransform;
    public GameObject crosshairPrefab;
    private float crosshairLifetime = 0.5f;
    private float reloadTime = 0.5f;

    private bool isReloading = false;
    private SpriteRenderer cannonRenderer;
    private GameVibroAudio _gameVibroAudio;

    void Start()
    {
        _gameVibroAudio = GetComponent<GameVibroAudio>();
        cannonRenderer = cannonTransform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isReloading && !BurgersCounter.isFinished)
        {
            Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapPosition.z = 0;
            ShootCandy(tapPosition);
            StartCoroutine(SpawnCrosshair(tapPosition));
            StartCoroutine(Reload());
        }
    }

    void ShootCandy(Vector3 targetPosition)
    {
        _gameVibroAudio.PlayShotFeedBack();
        Vector3 direction = targetPosition - cannonTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        cannonTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

        GameObject candy = Instantiate(candyPrefab, cannonTransform.position, Quaternion.identity);
        candy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        Rigidbody2D rb = candy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * 10f;
        }
    }

    IEnumerator SpawnCrosshair(Vector3 position)
    {
        GameObject crosshair = Instantiate(crosshairPrefab, position, Quaternion.identity);
        SpriteRenderer crosshairRenderer = crosshair.GetComponent<SpriteRenderer>();
        Color originalColor = crosshairRenderer.color;

        float elapsedTime = 0f;

        while (elapsedTime < crosshairLifetime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / crosshairLifetime);
            crosshairRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Destroy(crosshair);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        cannonRenderer.color = Color.red;
        yield return new WaitForSeconds(reloadTime);
        cannonRenderer.color = Color.white;
        isReloading = false;
    }
}
