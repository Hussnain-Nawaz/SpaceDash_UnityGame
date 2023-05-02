using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointSpawn : MonoBehaviour
{
    public GameObject circlePrefab;
    private float zOffset = 30f;
    private bool checkpointSpawned = false;
    private bool finalCheckPoint = false;
    private GameObject currentCircle;
    public GameObject finalPrefab;
    static public int checkLevel=1;

    private void Start(){
        finalPrefab = GameObject.Find("Magic circle");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !checkpointSpawned)
        {
            currentCircle = GameObject.Find("Freeze circle");
            if (Countdown.points == 150 && checkLevel==1 && !finalCheckPoint)
            {
                finalCheckPoint = true;
                checkpointSpawned = true;
                Vector3 spawnPosition = new Vector3(Random.Range(-1, -15), Random.Range(-1, -15), currentCircle.transform.position.z + zOffset);
                Quaternion spawnRotation = currentCircle.transform.rotation;
                Destroy(currentCircle);
                GameObject newObject = Instantiate(Countdown.finalPrefab, spawnPosition, spawnRotation);
            }else if (Countdown.points == 150 && checkLevel == 2 && !finalCheckPoint)
            {
                finalCheckPoint = true;
                checkpointSpawned = true;
                Vector3 spawnPosition = new Vector3(Random.Range(-1, -15), Random.Range(-1, -15), currentCircle.transform.position.z + zOffset);
                Quaternion spawnRotation = currentCircle.transform.rotation;
                Destroy(currentCircle);
                GameObject newObject = Instantiate(Countdown.finalPrefab2, spawnPosition, spawnRotation);
            }
            else if (Countdown.points == 150 && checkLevel == 3 && !finalCheckPoint)
            {
                finalCheckPoint = true;
                checkpointSpawned = true;
                Vector3 spawnPosition = new Vector3(Random.Range(-1, -15), Random.Range(-1, -15), currentCircle.transform.position.z + zOffset);
                Quaternion spawnRotation = currentCircle.transform.rotation;
                Destroy(currentCircle);
                GameObject newObject = Instantiate(Countdown.finalPrefab3, spawnPosition, spawnRotation);
            }
            else { 
            Countdown.currentTime += 5f;
            Countdown.points += 50;
            checkpointSpawned = true;
            Vector3 spawnPosition = new Vector3(Random.Range(-1, -15), Random.Range(-1, -15), currentCircle.transform.position.z + zOffset);
            Quaternion spawnRotation = currentCircle.transform.rotation;
            Destroy(currentCircle);
            GameObject newObject = Instantiate(circlePrefab, spawnPosition, spawnRotation);
            newObject.name = circlePrefab.name;
            }

        }

    }
    
}
