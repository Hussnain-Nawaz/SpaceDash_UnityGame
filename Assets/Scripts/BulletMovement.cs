using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    private void Start()
    {
        // Move the bullet forward in its local space
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ResetValueLvl3.canvas2.SetActive(true);
            Countdown.Gameover = true;
            ResetValueLvl3.spaceship.SetActive(false);
        }
    }
}
