using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject[] asteroids;
    private float spawnDelay = 1f;
    private float speed = 13f;
    public float xRangeMin = -15f;
    public float xRangeMax = -1f;
    public float yRangeMin = -15f;
    public float yRangeMax = -1f;
    public float zOffset = 100f;

    private void Update()
    {
        if (Time.time % spawnDelay < Time.deltaTime)
        {
            StartCoroutine(SpawnAsteroids());
        }
    }

    private IEnumerator SpawnAsteroids()
    {
        // Choose a random asteroid prefab from the array
        GameObject asteroidPrefab = asteroids[Random.Range(0, asteroids.Length)];

        // Spawn the asteroid at a random position in front of the player
        Vector3 spawnPosition = transform.position + transform.forward * zOffset + new Vector3(Random.Range(xRangeMin, xRangeMax), Random.Range(yRangeMin, yRangeMax), 0f);
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Rotate the asteroid towards the player
        asteroid.transform.LookAt(transform);

        // Move the asteroid towards the player at a constant speed
        while (Vector3.Distance(asteroid.transform.position, transform.position) > 2f)
        {
            // Speed up the rotation of the asteroid as it moves towards the player
            asteroid.transform.RotateAround(asteroid.transform.position, asteroid.transform.forward, Time.deltaTime * speed * 10f);

            asteroid.transform.position += asteroid.transform.forward * speed * Time.deltaTime;

            // Destroy the asteroid if it gets behind the spaceship
            if (Vector3.Dot(asteroid.transform.position - transform.position, transform.forward) < -5f)
            {
                Destroy(asteroid);
                break;
            }

            yield return null;
        }
    }
}






