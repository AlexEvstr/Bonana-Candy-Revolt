using UnityEngine;
using System.Collections;

public class CandyShooter : MonoBehaviour
{
    public GameObject candyPrefab;
    public Transform cannonTransform;
    public GameObject crosshairPrefab;
    public float crosshairLifetime = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tapPosition.z = 0;
            ShootCandy(tapPosition);
            StartCoroutine(SpawnCrosshair(tapPosition));
        }
    }

    void ShootCandy(Vector3 targetPosition)
    {
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
}
