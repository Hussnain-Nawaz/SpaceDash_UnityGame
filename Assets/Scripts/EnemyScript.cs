using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float xRange = 30.0f;
    public float yRange = 10.0f;
    public float bulletSpeed = 15.0f;
    public GameObject bulletPrefab;

    private float xSpeed = -5.0f;  // Reverse direction from EnemyScript
    private float xOffset = 0.0f;
    private Transform playerTransform;
    private float lastShootTime = 0.0f;

    void Start()
    {
        GameObject player = GameObject.Find("Example1NoInterior_Grey");
        if (!player)
        {
            Debug.Log("Player not found");
        }
        playerTransform = player.transform;
        xOffset = transform.position.x - playerTransform.position.x;
        // Start shooting bullets immediately
        lastShootTime = Time.time - 1.0f;
    }

    void Update()
    {
        // Move spaceship left and right within x range
        float newX = Mathf.Clamp(transform.position.x + (xSpeed * Time.deltaTime), -xRange, xRange);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Reverse x speed if spaceship hits x range limit
        if (transform.position.x <= -xRange || transform.position.x >= xRange)
        {
            xSpeed *= -1.0f;
        }

        // Shoot bullet if it's been at least 1 second since the last shot
        if (Time.time - lastShootTime >= 1.0f)
        {
            // Calculate bullet direction towards player
            Vector3 bulletDirection = (playerTransform.position - transform.position).normalized;

            // Instantiate bullet prefab with offset from spaceship
            GameObject bullet = Instantiate(bulletPrefab, transform.position + (bulletDirection * 100.0f), Quaternion.identity);

            // Set bullet velocity in the direction towards the player
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = bulletDirection * bulletSpeed;
            bulletRigidbody.angularVelocity = Vector3.zero;

            // Set bullet rotation to face the direction it's moving in
            bullet.transform.rotation = Quaternion.LookRotation(bulletRigidbody.velocity, Vector3.up);

            // Destroy bullet if it passes behind the spaceship
            StartCoroutine(DestroyBullet(bullet));

            // Update last shoot time
            lastShootTime = Time.time;
        }
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2.0f);  // Wait 2 seconds before checking bullet position
        if (bullet.transform.position.x < transform.position.x)
        {
            Destroy(bullet);
        }
    }
}
